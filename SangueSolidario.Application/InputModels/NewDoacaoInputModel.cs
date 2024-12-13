using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.InputModels
{
    public class NewDoacaoInputModel
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        //public Doador Doador { get; set; }
        //public DoacaoStatusEnum Status { get; private set; }


        //new Doacao {  DataDoacao = DateTime.Now.AddDays(-30), QuantidadeML = 450 },
    }
}
