using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionUsuariosIntereses : IEntityTypeConfiguration<UsuariosIntereses>
    {
        public void Configure(EntityTypeBuilder<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses> builder)
        {
            builder.ToTable("UsuariosInteres");
            builder.HasKey(ui => ui.IdUsuarioInteres);
            builder.Property(ui => ui.IdUsuario)
                .IsRequired();
            builder.Property(ui => ui.IdInteres)
                .IsRequired();
        }
    }
}