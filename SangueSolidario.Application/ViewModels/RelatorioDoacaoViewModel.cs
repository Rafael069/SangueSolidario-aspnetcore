using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class RelatorioDoacaoViewModel
    {
        public int IdDoador { get; set; }
        public string NomeDoador { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
    }
}
