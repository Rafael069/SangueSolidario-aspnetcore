using System;
using System.Collections.Generic;
using SangueSolidario.Core.Entities;





namespace SangueSolidario.Infrastructure.Persistence
{
    public class SangueSolidarioDbContext
    {
        // Listas em memória para simular tabelas do banco de dados
        public List<Doador> Doadores { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public List<EstoqueSangue> EstoquesSangue { get; set; }

        public SangueSolidarioDbContext()
        {
            // Inicializar as listas com dados simulados

            Enderecos = new List<Endereco>
            {
                new Endereco { Logradouro = "Rua A", Cidade = "Cidade X", Estado = "Estado Y", CEP = "12345-678" },
                new Endereco { Logradouro = "Avenida B", Cidade = "Cidade Z", Estado = "Estado W", CEP = "87654-321" }
            };

            Doacoes = new List<Doacao>
            {
                new Doacao {  DataDoacao = DateTime.Now.AddDays(-30), QuantidadeML = 450 },
                new Doacao {  DataDoacao = DateTime.Now.AddDays(-10), QuantidadeML = 420 }
            };


            Doadores = new List<Doador>
            {
                new Doador { NomeCompleto = "João Silva", Email = "joao@example.com", DataNascimento = new DateTime(1990, 5, 20), Genero = "Masculino", Peso = 75, TipoSanguineo = "A+", FatorRh = "+"},
                new Doador { NomeCompleto = "Maria Oliveira", Email = "maria@example.com", DataNascimento = new DateTime(1985, 8, 15), Genero = "Feminino", Peso = 65, TipoSanguineo = "B-", FatorRh = "-" }
            };
          

            EstoquesSangue = new List<EstoqueSangue>
            {
                new EstoqueSangue { TipoSanguineo = "A+", FatorRh = "+", QuantidadeML = 1000 },
                new EstoqueSangue { TipoSanguineo = "B-", FatorRh = "-", QuantidadeML = 500 }
            };



        }
    }
}

