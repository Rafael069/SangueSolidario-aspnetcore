using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.InputModels
{
    public class NewEstoqueDeSangueInputModel
    {
        //public int Id { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeML { get; set; }
        //public EstoquesSangueEnum Status { get; set; }

    }
}
