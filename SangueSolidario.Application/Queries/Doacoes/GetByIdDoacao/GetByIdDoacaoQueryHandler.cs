using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Queries.Doador.GetByIdDoador;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doacoes.GetByIdDoacao
{
    public class GetByIdDoacaoQueryHandler : IRequestHandler<GetByIdDoacaoQuery, DoacaoDetailsViewModel>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetByIdDoacaoQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<DoacaoDetailsViewModel> Handle(GetByIdDoacaoQuery request, CancellationToken cancellationToken)
        {
            var doacao = await _dbcontext.Doacoes.SingleOrDefaultAsync(dc => dc.Id == request.Id);

            if (doacao.Status == DoacaoStatusEnum.Removido)
                return null;

            var doacoesDetailsViewModel = new DoacaoDetailsViewModel(
                doacao.Id,
                doacao.IdDoador,
                doacao.DataDoacao,
                doacao.QuantidadeML,
                doacao.Doador
                );

            return doacoesDetailsViewModel;
        }
    }
}
