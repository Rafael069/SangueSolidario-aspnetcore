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

namespace SangueSolidario.Application.Queries.Enderecos.GetAllEndereco
{
    public class GetAllEnderecoQueryHandler : IRequestHandler<GetAllEnderecoQuery, List<EnderecoViewModel>>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetAllEnderecoQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<EnderecoViewModel>> Handle(GetAllEnderecoQuery request, CancellationToken cancellationToken)
        {
            var enderecos = _dbcontext.Enderecos;

            // Filtrando livros ativos
            var enderecosAtivas = await _dbcontext.Enderecos
                .Where(e => e.Status == EnderecoStatusEnum.Ativo)
                .ToListAsync(cancellationToken);

            var enderecosViewModel = enderecosAtivas
            .Select(e => new EnderecoViewModel(e.Id, e.Logradouro, e.Cidade, e.Estado, e.CEP))
            .ToList();

            return enderecosViewModel;
        }
    }
}
