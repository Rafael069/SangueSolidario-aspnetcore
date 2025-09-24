using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.EstoquesDeSangue.GetByIdEstoqueDeSangue
{
    public class GetByIdEstoqueDeSangueQuery : IRequest<EstoqueDeSangueDetailsViewModel>
    {
        public GetByIdEstoqueDeSangueQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
