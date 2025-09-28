using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Commands.Doacaoes.DeleteDoacao;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.DeleteEstoquesDeSangue
{
    public class DeleteEstoquesDeSangueCommandHandler : IRequestHandler<DeleteEstoquesDeSangueCommand, Unit>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public DeleteEstoquesDeSangueCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteEstoquesDeSangueCommand request, CancellationToken cancellationToken)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(es => es.Id == request.Id);

            estoqueDeSangue.DeleteEstoque();
            await _dbcontext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
