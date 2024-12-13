using System;
using System.Collections.Generic;
using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;


namespace SangueSolidario.Infrastructure.Persistence
{
    public class SangueSolidarioDbContext
    {
       

        public SangueSolidarioDbContext()
        {
            // Inicializar as listas com dados simulados

            Enderecos = new List<Endereco>
            {
                new Endereco {Id = 1, Logradouro = "Rua A", Cidade = "Cidade X", Estado = "Estado Y", CEP = "c", Status = EnderecoStatusEnum.Ativo },
                new Endereco {Id = 2, Logradouro = "Avenida B", Cidade = "Cidade Z", Estado = "Estado W", CEP = "87654-321",Status = EnderecoStatusEnum.Ativo }
            };

            Doacoes = new List<Doacao>
            {
                new Doacao {Id = 1, DataDoacao = DateTime.Now.AddDays(-30), QuantidadeML = 450, Status = DoacaoStatusEnum.Ativo },
                new Doacao {Id = 2,  DataDoacao = DateTime.Now.AddDays(-10), QuantidadeML = 420, Status = DoacaoStatusEnum.Ativo  }
            };


            Doadores = new List<Doador>
            {
                new Doador {Id = 1, NomeCompleto = "João Silva", Email = "joao@example.com", DataNascimento = new DateTime(1990, 5, 20), Genero = "Masculino", Peso = 75, TipoSanguineo = "A+", FatorRh = "+", Status = DoadorStatusEnum.Ativo},
                new Doador {Id = 2, NomeCompleto = "Maria Oliveira", Email = "maria@example.com", DataNascimento = new DateTime(1985, 8, 15), Genero = "Feminino", Peso = 65, TipoSanguineo = "B-", FatorRh = "-" ,Status = DoadorStatusEnum.Ativo}
            };
          

            EstoquesSangue = new List<EstoqueSangue>
            {
                new EstoqueSangue {Id = 1,TipoSanguineo = "A+", FatorRh = "+", QuantidadeML = 1000, Status = EstoquesSangueEnum.Ativo },
                new EstoqueSangue {Id = 2, TipoSanguineo = "B-", FatorRh = "-", QuantidadeML = 500, Status = EstoquesSangueEnum.Ativo }
            };



        }


        // Listas em memória para simular tabelas do banco de dados
        public List<Doador> Doadores { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public List<EstoqueSangue> EstoquesSangue { get; set; }
    }
}

