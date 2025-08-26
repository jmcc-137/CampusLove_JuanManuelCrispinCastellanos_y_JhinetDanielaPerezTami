using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionTiposInteracciones : IEntityTypeConfiguration<TiposInteracciones>
    {
        public void Configure(EntityTypeBuilder<TiposInteracciones> builder)
        {
            builder.ToTable("TiposInteracciones");
            builder.HasKey(ti => ti.IdTipoInteraccion);
            builder.Property(ti => ti.NombreTipo)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}