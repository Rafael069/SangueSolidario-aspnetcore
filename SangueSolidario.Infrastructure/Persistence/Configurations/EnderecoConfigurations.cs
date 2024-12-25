using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Infrastructure.Persistence.Configurations
{
    public class EnderecoConfigurations : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            // Relacionamentos Endereco

            builder
                .HasKey(e => e.Id);


            builder
                        .HasOne(e => e.Doador)
                        .WithOne(d => d.Endereco)
                        .HasForeignKey<Endereco>(e => e.IdDoador)
                        .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
