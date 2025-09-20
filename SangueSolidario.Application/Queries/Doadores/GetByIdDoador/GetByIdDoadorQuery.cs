using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doador.GetByIdDoador
{
    public class GetByIdDoadorQuery : IRequest<DoadorDetailsViewModel>
    {
        public GetByIdDoadorQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
