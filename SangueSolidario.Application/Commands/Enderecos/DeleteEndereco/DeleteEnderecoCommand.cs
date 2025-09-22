using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Enderecos.DeleteEndereco
{
    public class DeleteEnderecoCommand : IRequest<Unit>
    {
        public DeleteEnderecoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
