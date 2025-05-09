﻿using SangueSolidario.Core.Entities;
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
        public DoacaoViewModel(int id, int id_doador, DateTime dataDoacao)
        {
            Id = id;
            IdDoador = id_doador;
            DataDoacao = dataDoacao;
        }


        public int Id { get; private set; }
        public int IdDoador { get; private set; }
        public DateTime DataDoacao { get; private set; }

    }
}
