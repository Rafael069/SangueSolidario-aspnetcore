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

namespace SangueSolidario.Application.Queries.Enderecos.GetByIdEndereco
{
    public class GetByIdEnderecoHandler : IRequestHandler<GetByIdEnderecoQuery, EnderecoDetailsViewModel>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        public GetByIdEnderecoHandler(SangueSolidarioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<EnderecoDetailsViewModel> Handle(GetByIdEnderecoQuery request, CancellationToken cancellationToken)
        {
            var endereco = await _dbcontext.Enderecos.SingleOrDefaultAsync(d => d.Id == request.Id);

            if (endereco.Status == EnderecoStatusEnum.Removido)
                return null;

            var enderecoDetailsViewModel = new EnderecoDetailsViewModel(
                endereco.Id,
                endereco.Logradouro,
                endereco.Cidade,
                endereco.Estado,
                endereco.CEP,
                endereco.IdDoador,
                endereco.Doador
                );

            return enderecoDetailsViewModel;
        }
    }
}
