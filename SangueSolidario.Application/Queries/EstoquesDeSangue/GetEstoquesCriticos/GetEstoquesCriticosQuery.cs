using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetEstoquesCriticos
{
    public class GetEstoquesCriticosQuery : IRequest<List<EstoqueDeSangueDetailsViewModel>>
    {
    }
}
