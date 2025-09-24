using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doacoes.GetByIdDoacao
{
    public class GetByIdDoacaoQuery : IRequest<DoacaoDetailsViewModel>
    {
        public GetByIdDoacaoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
