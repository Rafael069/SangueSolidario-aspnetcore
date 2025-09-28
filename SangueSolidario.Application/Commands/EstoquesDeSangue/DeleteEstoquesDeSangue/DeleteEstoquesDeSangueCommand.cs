using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.DeleteEstoquesDeSangue
{
    public class DeleteEstoquesDeSangueCommand : IRequest<Unit>
    {
        public DeleteEstoquesDeSangueCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
