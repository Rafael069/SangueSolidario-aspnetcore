using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Enderecos.CreateEndereco
{
    public class CreateEnderecoCommand : IRequest<int>
    {
        //public CreateEnderecoCommand(string cep, int id)
        //{
        //    Cep = cep;
        //    Id = id;
        //}
        //public string Cep { get; private set; }
        //public int Id { get; private set; }

        public string CEP { get; private set; }
        public int DoadorId { get; private set; }

        public CreateEnderecoCommand(string cep, int doadorId)
        {
            CEP = cep;
            DoadorId = doadorId;
        }
    }
}
