using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionMaches : IEntityTypeConfiguration<UsuariosIntereses>
    {
        public void Configure(EntityTypeBuilder<UsuariosIntereses> builder)
        {
            builder.ToTable("UsuariosIntereses");
            builder.HasKey(ui => ui.IdUsuarioInteres);
            builder.Property(ui => ui.FechaRegistro)
                .IsRequired();
        }
    }
}