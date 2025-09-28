using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Queries.EstoquesDeSangue.GetAllEstoqueDeSangue;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetRelQtdPorTipo
{
    public class GetRelQtdPorTipoQueryHandler : IRequestHandler<GetRelQtdPorTipoQuery, List<RelatorioEstoqueSangueViewModel>>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public GetRelQtdPorTipoQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        #region Relatório sobre a quantidade total de sangue por tipo disponível.

        public async Task<List<RelatorioEstoqueSangueViewModel>> Handle(GetRelQtdPorTipoQuery request, CancellationToken cancellationToken)
        {
            var relatorio = await _dbcontext.EstoquesSangue
                .Where(es => es.Status == EstoquesSangueEnum.Ativo)
                .GroupBy(es => new { es.TipoSanguineo, es.FatorRh })
                .Select(group => new RelatorioEstoqueSangueViewModel
                {
                    TipoSanguineo = group.Key.TipoSanguineo,
                    FatorRh = group.Key.FatorRh,
                    QuantidadeTotalML = group.Sum(es => es.QuantidadeML)
                })
                .ToListAsync();

            return relatorio;
        }

        #endregion
    }
}
