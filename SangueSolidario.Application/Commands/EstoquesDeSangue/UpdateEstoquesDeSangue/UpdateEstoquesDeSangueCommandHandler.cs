using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Commands.Doacaoes.UpdateDoacao;
using SangueSolidario.Core.Entities;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.UpdateEstoquesDeSangue
{
    public class UpdateEstoquesDeSangueCommandHandler : IRequestHandler<UpdateEstoquesDeSangueCommand, Unit>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public UpdateEstoquesDeSangueCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Unit> Handle(UpdateEstoquesDeSangueCommand request, CancellationToken cancellationToken)
        {
            //var estoque = await _dbcontext.EstoquesSangue
            //    .FirstOrDefaultAsync(e => e.TipoSanguineo == request.TipoSanguineo && e.FatorRh == request.FatorRh);

            //if (estoque == null)
            //{
            //    // Se não existir, cria um novo registro no estoque
            //    estoque = new EstoqueSangue(doador.TipoSanguineo, doador.FatorRh, quantidadeML);
            //   await _dbcontext.EstoquesSangue.Add(estoque);
            //}
            //else
            //{
            //    // Se já existir, soma a quantidade doada
            //    estoque.QuantidadeML += quantidadeML;
            //    await _dbcontext.EstoquesSangue.Update(estoque);
            //}

            //_dbcontext.SaveChanges();


            var estoque = await _dbcontext.EstoquesSangue
                .FirstOrDefaultAsync(e =>
                    e.TipoSanguineo == request.Doador.TipoSanguineo &&
                    e.FatorRh == request.Doador.FatorRh,
                    cancellationToken);

            if (estoque == null)
            {
                // Se não existir, cria um novo registro no estoque
                estoque = new EstoqueSangue(
                    request.Doador.TipoSanguineo,
                    request.Doador.FatorRh,
                    request.QuantidadeML);

                await _dbcontext.EstoquesSangue.AddAsync(estoque, cancellationToken);
            }
            else
            {
                // Se já existir, soma a quantidade doada
                estoque.QuantidadeML += request.QuantidadeML;
            }

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
