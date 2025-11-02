using MediatR;
using SangueSolidario.Core.Entities;
using SangueSolidario.Infrastructure.Persistence;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SangueSolidario.Application.Commands.Enderecos.CreateEndereco
{
    public class CreateEnderecoCommandHandler : IRequestHandler<CreateEnderecoCommand, int>
    {
        private readonly SangueSolidarioDbContext _dbcontext;
        private readonly HttpClient _httpClient;

        public CreateEnderecoCommandHandler(SangueSolidarioDbContext dbcontext, HttpClient httpClient)
        {
            _dbcontext = dbcontext;
            _httpClient = httpClient;
        }

        public async Task<int> Handle(CreateEnderecoCommand request, CancellationToken cancellationToken)
        {
            // 1️ Chama a API do ViaCEP
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{request.CEP}/json/");
            response.EnsureSuccessStatusCode();

            // 2️ Lê o JSON e mapeia para um record local
            var enderecoData = await response.Content.ReadAsStringAsync(cancellationToken);

            var viaCepEndereco = JsonSerializer.Deserialize<ViaCepResponse>(enderecoData);

            // 3️ Cria a entidade Endereco
            var endereco = new Endereco(
                viaCepEndereco.Logradouro,
                viaCepEndereco.Localidade,
                viaCepEndereco.Uf,
                viaCepEndereco.Cep,
                request.DoadorId // Id do doador vindo do Command
            );

            await _dbcontext.Enderecos.AddAsync(endereco, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return endereco.Id;
        }

        // 4 Record interno apenas para deserializar o ViaCEP
        private record ViaCepResponse(
            [property: JsonPropertyName("logradouro")] string Logradouro,
            [property: JsonPropertyName("localidade")] string Localidade,
            [property: JsonPropertyName("uf")] string Uf,
            [property: JsonPropertyName("cep")] string Cep
        );
    }
}
