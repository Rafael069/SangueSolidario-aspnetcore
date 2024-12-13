using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;

namespace SangueSolidario.Core.Entities
{
    public class Doacao /*:  BaseEntity*/
    {
        public int Id { get; set; }
        public int DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public Doador Doador { get; set; }
        public DoacaoStatusEnum Status { get; set; }

        // Construtor

        public Doacao() { }

        public Doacao(int id, int doadorId, DateTime dataDoacao, int quantidadeML/*, Doador doador/*, DoacaoStatusEnum status*/)
        {
            Id = id;
            DoadorId = doadorId;
            //DataDoacao = dataDoacao;
            QuantidadeML = quantidadeML;
            Doador = Doador;
            Status = DoacaoStatusEnum.Ativo;
        }



        public void DeleteDoacao()
        {
            if (Status == DoacaoStatusEnum.Ativo)
            {
                Status = DoacaoStatusEnum.Removido;
            }
        }

        public void Update(int quantidadeML)
        {
            QuantidadeML = quantidadeML;
        }

    }
}
