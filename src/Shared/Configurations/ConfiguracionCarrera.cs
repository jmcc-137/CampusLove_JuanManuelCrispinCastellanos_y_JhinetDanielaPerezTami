using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionCarrera : IEntityTypeConfiguration<Carreras>
    {
        public void Configure(EntityTypeBuilder<Carreras> builder)
        {
            builder.ToTable("Carreras");
            builder.HasKey(c => c.IdCarrera);
            builder.Property(c => c.NombreCarrera)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}