using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace examen.scr.Shared.Context;
 
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    // los Dbset van aqui
    // public DbSet<Jugador> juagador => set<Jugadores>();
     // public DbSet<examen.src.Modules.moduloEjemplo.Domain.Entities.ejemplo> Ejemplos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}