using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class EstoqueDeSangueDetailsViewModel
    {
        public EstoqueDeSangueDetailsViewModel(int id, string tipoSanguineo, string fatorRh, int quantidadeML)
        {
            Id = id;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }


        public int Id { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeML { get; set; }
    }
}
