using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Queries.Doadores.GetAllDoador;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doacoes.GeAllDoacao
{
    public class GetAllDoacaoQueryHandler : IRequestHandler<GetAllDoacaoQuery, List<DoacaoViewModel>>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetAllDoacaoQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<List<DoacaoViewModel>> Handle(GetAllDoacaoQuery request, CancellationToken cancellationToken)
        {
            var doacoes = _dbcontext.Doacoes;

            // Filtrando  ativos
            var doacoesAtivas = await _dbcontext.Doacoes
                .Where(dc => dc.Status == DoacaoStatusEnum.Ativo)
                .ToListAsync(cancellationToken);

            var doacoesViewModel = doacoesAtivas
            .Select(dc => new DoacaoViewModel(dc.Id, dc.IdDoador, dc.DataDoacao, dc.QuantidadeML))
            .ToList();

            return doacoesViewModel;
        }
    }
}
