using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetRelQtdPorTipo;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetEstoquesCriticos
{
    public class GetEstoquesCriticosQueryHandler : IRequestHandler<GetEstoquesCriticosQuery, List<EstoqueDeSangueDetailsViewModel>>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public GetEstoquesCriticosQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<EstoqueDeSangueDetailsViewModel>> Handle(GetEstoquesCriticosQuery request, CancellationToken cancellationToken)
        {

            var estoquesCriticos = await _dbcontext.EstoquesSangue
                .Where(e => e.Status == EstoquesSangueEnum.Ativo && e.QuantidadeML < e.QuantidadeMinimaML)
                .Select(e => new EstoqueDeSangueDetailsViewModel(
                    e.Id,
                    e.TipoSanguineo,
                    e.FatorRh,
                    e.QuantidadeML
                ))
                .ToListAsync();

            return estoquesCriticos;
        }
    }
}
