using MediatR;
using SangueSolidario.Application.Commands.Doadores.UpdateDoador;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doacaoes.UpdateDoacao
{
    public class UpdateDoacaoCommandHandler : IRequestHandler<UpdateDoacaoCommand, Unit>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public UpdateDoacaoCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateDoacaoCommand request, CancellationToken cancellationToken)
        {
            var doacao = _dbcontext.Doacoes.SingleOrDefault(dc => dc.Id == request.Id);

            doacao.Update(request.QuantidadeML);
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

