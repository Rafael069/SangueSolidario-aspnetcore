using MediatR;
using SangueSolidario.Application.Commands.Doadores.CreateDoador;
using SangueSolidario.Application.InputModels;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        //Cria um novo endereço, agora integrando com ViaCepService
        public async Task<int> Handle(CreateEnderecoCommand request, CancellationToken cancellationToken)
        {
            // Fazendo a requisição à API do ViaCEP
           // var response = await _httpClient.GetAsync($"{request.Cep}/json/");
           var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{request.Cep}/json/");

            response.EnsureSuccessStatusCode();


            // Deserializando a resposta da API do ViaCEP
            var enderecoData = await response.Content.ReadAsStringAsync(cancellationToken);
            var viaCepEndereco = JsonSerializer.Deserialize<NewEnderecoInputModel>(enderecoData);

            // Criando a entidade Endereco
            var endereco = new Endereco(
                viaCepEndereco.Logradouro,
                viaCepEndereco.Cidade,
                viaCepEndereco.Estado,
                viaCepEndereco.CEP,
                   //viaCepEndereco.IdDoador = request.Id
                request.Id // o doadorId que veio do command
            );

            // Salvando no banco
            await _dbcontext.Enderecos.AddAsync(endereco, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return endereco.Id;
        }
    }
}
