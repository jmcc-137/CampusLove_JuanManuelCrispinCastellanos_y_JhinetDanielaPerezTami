using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionUsuarios : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.IdUsuario);
            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}