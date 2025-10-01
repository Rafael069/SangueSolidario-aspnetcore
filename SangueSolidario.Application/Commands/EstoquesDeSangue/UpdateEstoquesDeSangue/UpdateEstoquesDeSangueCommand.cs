using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.EstoquesDeSangue.UpdateEstoquesDeSangue
{
    public class UpdateEstoquesDeSangueCommand : IRequest<Unit>
    {
        public UpdateEstoquesDeSangueCommand(string tipoSanguineo, string fatorRh, int quantidadeML)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }

        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
