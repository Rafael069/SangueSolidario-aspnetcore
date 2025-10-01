using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doadores.DeleteDoador
{
    public class DeleteDoadorCommandHandler : IRequestHandler<DeleteDoadorCommand, Unit>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public DeleteDoadorCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteDoadorCommand request, CancellationToken cancellationToken)
        {
            var doadores = _dbcontext.Doadores.SingleOrDefault(d => d.Id == request.Id);

            doadores.DeleteDoador();
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
