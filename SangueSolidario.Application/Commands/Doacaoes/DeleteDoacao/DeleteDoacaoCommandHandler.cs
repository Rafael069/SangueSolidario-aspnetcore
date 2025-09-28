using MediatR;
using SangueSolidario.Application.Commands.Doadores.DeleteDoador;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doacaoes.DeleteDoacao
{
    public class DeleteDoacaoCommandHandler : IRequestHandler<DeleteDoacaoCommand, Unit>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public DeleteDoacaoCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteDoacaoCommand request, CancellationToken cancellationToken)
        {
            var doacoes = _dbcontext.Doacoes.SingleOrDefault(dc => dc.Id == request.Id);

            doacoes.DeleteDoacao();
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
