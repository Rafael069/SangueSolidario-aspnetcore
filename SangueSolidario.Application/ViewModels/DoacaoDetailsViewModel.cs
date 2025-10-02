using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class DoacaoDetailsViewModel
    {
        public DoacaoDetailsViewModel(int id, int doadorId, DateTime dataDoacao, int quantidadeML, Doador doador)
        {
            Id = id;
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
            Doador = doador;
        }



        public int Id { get;private set; }
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador Doador { get; private set; }


    }
}
