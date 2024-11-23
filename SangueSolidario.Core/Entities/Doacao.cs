using SangueSolidario.Core.Entities;
using System;
using System.Collections.Generic;

namespace SangueSolidario.Core.Entities
{
    public class Doacao :  BaseEntity
    {
        //public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public Doador Doador { get; set; }

        // Construtor

        public Doacao() { }

        public Doacao(/*int id,*/ int doadorId, DateTime dataDoacao, int quantidadeML)
        {
            //Id = id;
            DoadorId = doadorId;
            DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
        }



    }
}
