using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doadores.DeleteDoador
{
    public class DeleteDoadorCommand : IRequest<Unit>
    {
        public DeleteDoadorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
