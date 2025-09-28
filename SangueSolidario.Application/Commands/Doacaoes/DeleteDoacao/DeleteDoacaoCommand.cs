using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doacaoes.DeleteDoacao
{
    public class DeleteDoacaoCommand : IRequest<Unit>
    {
        public DeleteDoacaoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
