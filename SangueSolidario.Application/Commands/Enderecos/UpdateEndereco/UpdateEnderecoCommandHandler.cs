using MediatR;
using SangueSolidario.Application.Commands.Doadores.UpdateDoador;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Enderecos.UpdateEndereco
{
    public class UpdateEnderecoCommandHandler : IRequestHandler<UpdateEnderecoCommand, Unit>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public UpdateEnderecoCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateEnderecoCommand request, CancellationToken cancellationToken)
        {
            var endereco = _dbcontext.Enderecos.SingleOrDefault(e => e.Id == request.Id);

            endereco.Update(request.Logradouro, request.Cidade, request.Estado, request.CEP);
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
