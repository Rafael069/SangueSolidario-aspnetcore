using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;

namespace SangueSolidario.Core.Entities
{
    public class Doacao :  BaseEntity
    {
        public int IdDoador { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public Doador Doador { get; set; }
        public DoacaoStatusEnum Status { get; set; }

        // Construtor

        public Doacao() { }

        public Doacao(int Id_doador, DateTime dataDoacao, int quantidadeML/*, Doador doador/*, DoacaoStatusEnum status*/)
        {
            IdDoador = Id_doador;
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
