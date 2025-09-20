using MediatR;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doadores.UpdateDoador
{
    public class UpdateDoadorCommandHandler : IRequestHandler<UpdateDoadorCommand, Unit>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public UpdateDoadorCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateDoadorCommand request, CancellationToken cancellationToken)
        {
            var doador = _dbcontext.Doadores.SingleOrDefault(d => d.Id == request.Id);

            doador.Update(request.NomeCompleto, request.Email,
                          request.DataNascimento, request.Genero,
                          request.Peso, request.TipoSanguineo,
                          request.FatorRh);

            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
