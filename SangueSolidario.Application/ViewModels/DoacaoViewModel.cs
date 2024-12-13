using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class DoacaoViewModel
    {
        public DoacaoViewModel(int id, int doadorId, DateTime dataDoacao)
        {
            Id = id;
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
        }


        public int Id { get; private set; }
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }

    }
}
