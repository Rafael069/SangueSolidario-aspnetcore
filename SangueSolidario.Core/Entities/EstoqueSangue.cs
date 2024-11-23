using SangueSolidario.Core.Entities;
using System;
using System.Collections.Generic;

namespace SangueSolidario.Core.Entities
{
    public class EstoqueSangue : BaseEntity
    {
        //public int Id { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public int QuantidadeML { get; set; }

        public EstoqueSangue()
        {
        }

        public EstoqueSangue(/*int id,*/ string tipoSanguineo, string fatorRh, int quantidadeML)
        {
            //Id = id;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }



    }
}
