using MediatR;
using SangueSolidario.Application.Commands.Enderecos.CreateEndereco;
using SangueSolidario.Infrastructure.Persistence;



namespace SangueSolidario.Application.Commands.Doadores.CreateDoador
{
    // Tratar as informaçoes e guardar no banco de dados

    public class CreateDoadorCommandHandler : IRequestHandler<CreateDoadorCommand, int>
    {
        private readonly SangueSolidarioDbContext _dbcontext;
        private readonly IMediator _mediator;

        public CreateDoadorCommandHandler(SangueSolidarioDbContext dbcontext , IMediator mediator)
        {
            _dbcontext = dbcontext;
           _mediator = mediator;
        }

        public async Task<int> Handle(CreateDoadorCommand request, CancellationToken cancellationToken)
        {
            // Criando Doador
            var doador = new Doador(
            request.NomeCompleto,
            request.Email,
            request.DataNascimento,
            request.Genero,
            request.Peso,
            request.TipoSanguineo,
            request.FatorRh
            );

            // Associar o endereço ao doador


            // Adiciona o doador ao banco de dados
            await _dbcontext.Doadores.AddAsync(doador);
            await _dbcontext.SaveChangesAsync(); // Salvar o doador no banco

            //Criar Endereco
            //var enderecoId = await _enderecoService.CreateEndereco(request.CEP, doador.Id);

            // Criar endereço via MediatR
            var enderecoCommand = new CreateEnderecoCommand(request.CEP, doador.Id);
            var enderecoId = await _mediator.Send(enderecoCommand, cancellationToken);


            //Associar o endereço ao doador
            doador.IdEndereco = enderecoId;

            // Aualiza 

            _dbcontext.Doadores.Update(doador);
            await _dbcontext.SaveChangesAsync(); // Salvar o doador no banco

            return doador.Id;
        }
    }
}
