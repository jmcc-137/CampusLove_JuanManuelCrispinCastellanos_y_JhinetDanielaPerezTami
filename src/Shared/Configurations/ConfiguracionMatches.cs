using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Shared.Configurations
{
    public class ConfiguracionMatches : IEntityTypeConfiguration<Matches>
    {
        public void Configure(EntityTypeBuilder<Matches> builder)
        {
            builder.ToTable("Matches");
            builder.HasKey(m => m.IdMatch);
            builder.Property(m => m.FechaMatch).IsRequired();
            builder.Property(m => m.Activo).IsRequired();
        }
    }
}
