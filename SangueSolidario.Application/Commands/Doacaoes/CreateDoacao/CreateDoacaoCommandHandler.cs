using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Core.Entities;
using SangueSolidario.Infrastructure.Persistence;
using SangueSolidario.Application.Commands.EstoquesDeSangue.UpdateEstoquesDeSangue;

namespace SangueSolidario.Application.Commands.Doacaoes.CreateDoacao
{
    public class CreateDoacaoCommandHandler : IRequestHandler<CreateDoacaoCommand, int>
    {
        private readonly SangueSolidarioDbContext _dbcontext;
        private readonly IMediator _mediator;

        public CreateDoacaoCommandHandler(SangueSolidarioDbContext dbcontext, IMediator mediator)
        {
            _dbcontext = dbcontext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateDoacaoCommand request, CancellationToken cancellationToken)
        {
            // Buscar o doador
            var doador = await _dbcontext.Doadores
                .FirstOrDefaultAsync(d => d.Id == request.DoadorId, cancellationToken);

            if (doador == null)
            {
                throw new InvalidOperationException("Doador não encontrado.");
            }

            // Criar doação
            var doacao = new Doacao(request.DoadorId, request.DataDoacao, request.QuantidadeML);
            await _dbcontext.Doacoes.AddAsync(doacao, cancellationToken);

            // Disparar atualização de estoque (via outro Command/Handler)
            await _mediator.Send(
                new UpdateEstoquesDeSangueCommand
                (doador.TipoSanguineo, doador.FatorRh, request.QuantidadeML),
                cancellationToken
              
            );

            // Salvar tudo
            await _dbcontext.SaveChangesAsync(cancellationToken);

            return doacao.Id;
        }
    }
}
