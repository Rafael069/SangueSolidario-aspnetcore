using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class EstoqueDeSangueViewModel
    {
        public EstoqueDeSangueViewModel(int id, string tipoSanguineo)
        {
            Id = id;
            TipoSanguineo = tipoSanguineo;
        }

        public int Id { get; set; }
        public string TipoSanguineo { get; set; }
    }
}
