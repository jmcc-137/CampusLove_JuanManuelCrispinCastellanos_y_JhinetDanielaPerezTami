using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Intereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionInteres : IEntityTypeConfiguration<Intereses>
    {
        public void Configure(EntityTypeBuilder<Intereses> builder)
        {
            builder.ToTable("Intereses");
            builder.HasKey(i => i.IdInteres);
            builder.Property(i => i.NombreInteres)
                .IsRequired()
                .HasMaxLength(30);
            builder.HasIndex(i => i.NombreInteres).IsUnique();
        }
    }
}