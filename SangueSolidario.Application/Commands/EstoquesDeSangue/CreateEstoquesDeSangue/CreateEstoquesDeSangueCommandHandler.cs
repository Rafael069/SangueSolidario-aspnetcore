using MediatR;
using SangueSolidario.Application.Commands.Doacaoes.CreateDoacao;
using SangueSolidario.Core.Entities;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.CreateEstoquesDeSangue
{
    public class CreateEstoquesDeSangueCommandHandler : IRequestHandler<CreateEstoquesDeSangueCommand, int>
    {


        private readonly SangueSolidarioDbContext _dbcontext;

        public CreateEstoquesDeSangueCommandHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Handle(CreateEstoquesDeSangueCommand request, CancellationToken cancellationToken)
        {
            var estoqueDeSangue = new EstoqueSangue(request.TipoSanguineo, request.FatorRh, request.QuantidadeML/*,inputModel.Status*/);

            await _dbcontext.EstoquesSangue.AddAsync(estoqueDeSangue);
            await _dbcontext.SaveChangesAsync();


            return estoqueDeSangue.Id;
        }
    }
}
