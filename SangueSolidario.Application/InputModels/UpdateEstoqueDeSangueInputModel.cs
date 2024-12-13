using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.InputModels
{
    public class UpdateEstoqueDeSangueInputModel
    {
        public int Id { get; set; }
        public string TipoSanguineo { get; set; }
        public int QuantidadeML { get; set; }
    }
}
