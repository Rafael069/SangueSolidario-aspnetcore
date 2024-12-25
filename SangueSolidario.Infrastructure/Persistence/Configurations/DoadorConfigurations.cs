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
    public class DoadorConfigurations : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {

            // Relacionamentos Doador

            builder
            .HasKey(d => d.Id);

            builder
                        .HasOne(d => d.Endereco)
                        .WithOne(e => e.Doador)
                        .HasForeignKey<Doador>(d => d.IdEndereco)
                        .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
