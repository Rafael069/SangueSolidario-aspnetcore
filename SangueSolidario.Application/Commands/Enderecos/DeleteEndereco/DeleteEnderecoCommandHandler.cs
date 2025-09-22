using MediatR;
using SangueSolidario.Application.Commands.Doadores.DeleteDoador;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Enderecos.DeleteEndereco
{
    public class DeleteEnderecoCommandHandler : IRequestHandler<DeleteEnderecoCommand, Unit>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public DeleteEnderecoCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteEnderecoCommand request, CancellationToken cancellationToken)
        {
            var enderecos = _dbcontext.Enderecos.SingleOrDefault(d => d.Id == request.Id);

            enderecos.DeleteEndereco();
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
