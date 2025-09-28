using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.CreateEstoquesDeSangue
{
    public class CreateEstoquesDeSangueCommand : IRequest<int>
    {
        //public int Id { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeML { get; set; }
        //public EstoquesSangueEnum Status { get; set; }
    }
}
