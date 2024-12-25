using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;


namespace SangueSolidario.Infrastructure.Persistence
{
    public class SangueSolidarioDbContext : DbContext
    {

        // base vai para o construtor do DbContext
        public SangueSolidarioDbContext(DbContextOptions<SangueSolidarioDbContext> options ) : base(options)
        {           

        }

        
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<EstoqueSangue> EstoquesSangue { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());         
        }

    }
}

