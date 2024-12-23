using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;

namespace SangueSolidario.Core.Entities
{
    public class EstoqueSangue : BaseEntity
    {

        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeML { get; set; }
        public EstoquesSangueEnum Status { get; set; }

        public EstoqueSangue()
        {
        }

        public EstoqueSangue(string tipoSanguineo, string fatorRh, int quantidadeML/*, EstoquesSangueEnum status*/)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
            Status = EstoquesSangueEnum.Ativo;
        }




        public void DeleteEstoque()
        {
            if (Status == EstoquesSangueEnum.Ativo)
            {
                Status = EstoquesSangueEnum.Removido;
            }
        }

        public void Update(string tipoSanguineo ,int quantidadeML)
        {
            TipoSanguineo = tipoSanguineo;
            QuantidadeML = quantidadeML;
        }

    }
}
