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
    public class EstoqueSangueConfigurations : IEntityTypeConfiguration<EstoqueSangue>
    {
        public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
        {
            // Relacionamentos EstoqueSangue

            builder
                .HasKey(es => es.Id);

        }
    }
}
