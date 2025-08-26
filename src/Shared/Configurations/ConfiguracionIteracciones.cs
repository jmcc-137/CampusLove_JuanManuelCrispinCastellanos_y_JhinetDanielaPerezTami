using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionIteracciones: IEntityTypeConfiguration<Interacciones>
    {
        public void Configure(EntityTypeBuilder<Interacciones> builder)
        {
            builder.ToTable("Interacciones");
            builder.HasKey(i => i.IdInteraccion);
            builder.Property(i => i.FechaInteraccion)
                .IsRequired();
            builder.HasOne(i => i.TipoInteraccion)
                .WithMany(t => t.Interacciones)
                .HasForeignKey(i => i.IdTipoInteraccion);
        }
    }
}