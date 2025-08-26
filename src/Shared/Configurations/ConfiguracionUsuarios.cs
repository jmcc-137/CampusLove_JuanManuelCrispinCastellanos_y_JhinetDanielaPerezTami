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
                .HasMaxLength(50);

            builder.Property(u => u.Edad)
                .IsRequired();

            builder.Property(u => u.IdGenero)
                .IsRequired();

            builder.Property(u => u.IdCarrera)
                .IsRequired();

            builder.Property(u => u.FrasePerfil)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.NombreUsuario)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(u => u.Contrasena)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.CreditosDiarios)
                .HasDefaultValue(10);

            builder.Property(u => u.FechaUltimaInteraccion)
                .HasDefaultValueSql("NOW()");

            builder.Property(u => u.FechaRegistro)
                .HasDefaultValueSql("NOW()");

            builder.Property(u => u.Activo)
                .HasDefaultValue(true);

            // Relaciones con Genero y Carrera
            builder.HasOne(u => u.Genero)
                .WithMany(g => g.Usuarios)
                .HasForeignKey(u => u.IdGenero)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Carrera)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.IdCarrera)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones con otras entidades
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