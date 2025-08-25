using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.moduloEjemplo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Configurations
{
    public class configuracionEjemplo : IEntityTypeConfiguration<ejemplo>
    {
        public void Configure(EntityTypeBuilder<ejemplo> builder)
        {
            builder.ToTable("ejemplo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
        }
        
    }
}