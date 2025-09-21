using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Enderecos.GetByIdEndereco
{
    public class GetByIdEnderecoQuery : IRequest<EnderecoDetailsViewModel>
    {
        public GetByIdEnderecoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
