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
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doacoes.GetRelatorioDoacoesUltimos30Dias
{
    public class GetRelatorioDoacao30DiasQueryHandler : IRequestHandler<GetRelatorioDoacao30DiasQuery, List<RelatorioDoacaoViewModel>>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetRelatorioDoacao30DiasQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        #region Lógica de Doações nos Últimos 30 Dias com Informações dos Doadores
        public async Task<List<RelatorioDoacaoViewModel>> Handle(GetRelatorioDoacao30DiasQuery request, CancellationToken cancellationToken)
        {
            
            var dataLimite = DateTime.UtcNow.AddDays(-30);


            var doacoesRecentes = await _dbcontext.Doacoes
                .Where(d => d.DataDoacao >= dataLimite && d.Status == DoacaoStatusEnum.Ativo)
                .Select(d => new RelatorioDoacaoViewModel
                {
                    IdDoador = d.IdDoador,
                    NomeDoador = d.Doador.NomeCompleto,
                    TipoSanguineo = d.Doador.TipoSanguineo,
                    FatorRh = d.Doador.FatorRh,
                    DataDoacao = d.DataDoacao,
                    QuantidadeML = d.QuantidadeML
                })
                .ToListAsync();

            return doacoesRecentes;
        }

        #endregion
    }
}
