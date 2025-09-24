using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Queries.Doacoes.GeAllDoacao;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetAllEstoqueDeSangue
{
    public class GetAllEstoqueDeSangueQueryHandler : IRequestHandler<GetAllEstoqueDeSangueQuery, List<EstoqueDeSangueViewModel>>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetAllEstoqueDeSangueQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<EstoqueDeSangueViewModel>> Handle(GetAllEstoqueDeSangueQuery request, CancellationToken cancellationToken)
        {
            var estoquesDeSangue = _dbcontext.EstoquesSangue;

            // Filtrando estoques ativos
            var estoquesDeSangueAtivas = await _dbcontext.EstoquesSangue
                .Where(es => es.Status == EstoquesSangueEnum.Ativo)
                .ToListAsync(cancellationToken);


            var estoquesDeSangueViewModel = estoquesDeSangueAtivas
            .Select(es => new EstoqueDeSangueViewModel(es.Id, es.TipoSanguineo))
            .ToList();

            return estoquesDeSangueViewModel;
        }
    }
}
