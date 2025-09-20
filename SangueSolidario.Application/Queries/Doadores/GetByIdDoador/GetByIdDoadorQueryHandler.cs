using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doador.GetByIdDoador
{
    public class GetByIdDoadorQueryHandler : IRequestHandler<GetByIdDoadorQuery, DoadorDetailsViewModel>
    {
        private readonly SangueSolidarioDbContext _dbcontext;
        public GetByIdDoadorQueryHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Trás detalhes do doador bem como histórico de doações

        public async Task<DoadorDetailsViewModel> Handle(GetByIdDoadorQuery request, CancellationToken cancellationToken)
        {
            var doador = await _dbcontext.Doadores
                 // Trazer dados de endereços e doações
                 .Include(d => d.Endereco)
                 .Include(d => d.Doacoes)
                 .SingleOrDefaultAsync(d => d.Id == request.Id);

            if (doador == null || doador.Status == DoadorStatusEnum.Removido)
                return null;


            // Mapeia o Endereco para EnderecoViewModel
            var enderecoViewModel = new EnderecoViewModel(
                doador.Endereco.Id,
                doador.Endereco.Logradouro,
                doador.Endereco.Cidade,
                doador.Endereco.Estado,
                doador.Endereco.CEP
            );


            // Mapeia a lista de Doacao para DoacaoViewModel
            var doacoesViewModel = doador.Doacoes
                .Select(doacao => new DoacaoViewModel(
                    doacao.Id,
                    doacao.IdDoador,
                    doacao.DataDoacao,
                    doacao.QuantidadeML // <- ajuste para o nome real se for diferente
                ))
                .ToList();

            // Monta o ViewModel do doador

            var doadoresDetailsViewModel = new DoadorDetailsViewModel(
                doador.Id,
                doador.NomeCompleto,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRh,
                enderecoViewModel,
                doacoesViewModel,
                doador.Status
                );

            return doadoresDetailsViewModel;
        }
    }
}
