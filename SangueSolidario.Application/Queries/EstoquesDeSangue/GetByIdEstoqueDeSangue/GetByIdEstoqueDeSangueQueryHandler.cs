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

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetByIdEstoqueDeSangue
{
    public class GetByIdEstoqueDeSangueQueryHandler : IRequestHandler<GetByIdEstoqueDeSangueQuery, EstoqueDeSangueDetailsViewModel>
    {

        private readonly SangueSolidarioDbContext _dbcontext;

        public GetByIdEstoqueDeSangueQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<EstoqueDeSangueDetailsViewModel> Handle(GetByIdEstoqueDeSangueQuery request, CancellationToken cancellationToken)
        {
            var estoqueDeSangue = await _dbcontext.EstoquesSangue.SingleOrDefaultAsync(es => es.Id == request.Id);

            if (estoqueDeSangue.Status == EstoquesSangueEnum.Removido)
                return null;

            var estoqueDetailsViewModel = new EstoqueDeSangueDetailsViewModel(
                estoqueDeSangue.Id,
                estoqueDeSangue.TipoSanguineo,
                estoqueDeSangue.FatorRh,
                estoqueDeSangue.QuantidadeML
                );

            return estoqueDetailsViewModel;
        }
    }
}
