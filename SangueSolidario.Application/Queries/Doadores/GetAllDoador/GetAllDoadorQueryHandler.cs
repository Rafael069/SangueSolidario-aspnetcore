using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doadores.GetAllDoador
{
    public class GetAllDoadorQueryHandler : IRequestHandler<GetAllDoadorQuery, List<DoadorViewModel>>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetAllDoadorQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<DoadorViewModel>> Handle(GetAllDoadorQuery request, CancellationToken cancellationToken)
        {
            var doadores = _dbcontext.Doadores;

            // Filtrando doadores ativos
            //var doadoresAtivos = _dbcontext.Doadores
            //    .Where(d => d.Status == DoadorStatusEnum.Ativo)
            //    .ToList();

            // Filtrando doadores ativos

            var doadoresAtivos = await _dbcontext.Doadores
               .Where(d => d.Status == DoadorStatusEnum.Ativo)
               .ToListAsync(cancellationToken);

            // Projeta para o ViewModel
            var doadoresViewModel = doadoresAtivos
                .Select(d => new DoadorViewModel(
                    d.Id,
                    d.NomeCompleto,
                    d.Email,
                    d.DataNascimento,
                    d.Genero))
                .ToList();

            return doadoresViewModel;
        }
    }
}

