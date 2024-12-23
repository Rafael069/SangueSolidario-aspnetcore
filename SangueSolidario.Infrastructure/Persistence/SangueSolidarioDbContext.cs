using System;
using System.Collections.Generic;
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
            // Relacionamentos Doador

            modelBuilder.Entity<Doador>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Doador>()
                        .HasOne(d => d.Endereco)
                        .WithOne(e => e.Doador)
                        .HasForeignKey<Doador>(d => d.IdEndereco)
                        .OnDelete(DeleteBehavior.Restrict);


            // Relacionamentos Endereco

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);


            modelBuilder.Entity<Endereco>()
                        .HasOne(e => e.Doador)
                        .WithOne(d => d.Endereco)
                        .HasForeignKey<Endereco>(e => e.IdDoador)
                        .OnDelete(DeleteBehavior.Restrict);

            // Relacionamentos Doacoes

            modelBuilder.Entity<Doacao>()
                .HasKey(dc => dc.Id);

            modelBuilder.Entity<Doacao>()
                       .HasOne(dc => dc.Doador)
                       .WithMany(d => d.Doacoes)
                       .HasForeignKey(dc => dc.IdDoador)
                       .OnDelete(DeleteBehavior.Restrict);

            // Relacionamentos EstoqueSangue

            modelBuilder.Entity<EstoqueSangue>()
                .HasKey(es => es.Id);

        }

    }
}

