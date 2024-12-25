using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SangueSolidario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Infrastructure.Persistence.Configurations
{
    public class DoacaoConfigurations : IEntityTypeConfiguration<Doacao>
    {
        public void Configure(EntityTypeBuilder<Doacao> builder)
        {

            // Relacionamentos Doacoes

            builder
                 .HasKey(dc => dc.Id);

            builder
                        .HasOne(dc => dc.Doador)
                       .WithMany(d => d.Doacoes)
                       .HasForeignKey(dc => dc.IdDoador)
                       .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
