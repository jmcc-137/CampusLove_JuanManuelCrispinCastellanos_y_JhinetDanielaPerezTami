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
                
            builder.HasMany(u => u.InteraccionesOrigen)
                .WithOne(i => i.UsuarioOrigen)
                .HasForeignKey(i => i.IdUsuarioOrigen)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.InteraccionesDestino)
                .WithOne(i => i.UsuarioDestino)
                .HasForeignKey(i => i.IdUsuarioDestino)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Matches1)
                .WithOne(m => m.Usuario1)
                .HasForeignKey(m => m.IdUsuario1)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Matches2)
                .WithOne(m => m.Usuario2)
                .HasForeignKey(m => m.IdUsuario2)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}