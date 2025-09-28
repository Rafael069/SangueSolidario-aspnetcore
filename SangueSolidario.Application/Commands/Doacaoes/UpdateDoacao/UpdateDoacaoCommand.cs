using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doacaoes.UpdateDoacao
{
    public class UpdateDoacaoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int QuantidadeML { get; set; }
    }
}
