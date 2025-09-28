using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.UpdateEstoquesDeSangue
{
    public class UpdateEstoquesDeSangueCommand : IRequest<Unit>
    {
        public UpdateEstoquesDeSangueCommand(Doador doador, int quantidadeML)
        {
            Doador = doador;
            QuantidadeML = quantidadeML;
        }

        public Doador Doador { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
