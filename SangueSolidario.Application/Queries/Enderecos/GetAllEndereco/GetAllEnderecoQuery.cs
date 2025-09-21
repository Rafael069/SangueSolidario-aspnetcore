using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Enderecos.GetAllEndereco
{
    public class GetAllEnderecoQuery : IRequest<List<EnderecoViewModel>>
    {
    }
}
