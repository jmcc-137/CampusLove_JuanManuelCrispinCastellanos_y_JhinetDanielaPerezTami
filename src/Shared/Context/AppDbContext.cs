using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    // los Dbset van aqui
    // public DbSet<Jugador> juagador => set<Jugadores>();
        public DbSet<Usuarios.Domain.Entities.Usuarios> Usuarios => Set<Usuarios.Domain.Entities.Usuarios>();
        public DbSet<Generos.Domain.Entities.Genero> Generos => Set<Generos.Domain.Entities.Genero>();
        public DbSet<Carreras.Domain.Entities.Carreras> Carreras => Set<Carreras.Domain.Entities.Carreras>();
        public DbSet<Intereses.Domain.Entities.Intereses> Intereses => Set<Intereses.Domain.Entities.Intereses>();

    public DbSet<Matches.Domain.Entities.Matches> Matches => Set<Matches.Domain.Entities.Matches>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }


}
