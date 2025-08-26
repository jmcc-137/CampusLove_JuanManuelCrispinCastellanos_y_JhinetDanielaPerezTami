using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{
    using Spectre.Console;
    using Microsoft.EntityFrameworkCore;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Context;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Intereses.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities;

    public class EditarUsuarioService : IEditarCuentaServices
    {
        private readonly AppDbContext _context;
        public EditarUsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EditarCuenta(int idUsuario)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.UsuariosIntereses)
                .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
            if (usuario == null)
            {
                AnsiConsole.MarkupLine("[red]Usuario no encontrado.[/]");
                return false;
            }

            // Obtener opciones predefinidas y de BD
            var interesesPredefinidos = new List<string> { "Deportes", "Música", "Cine", "Lectura", "Viajes", "Tecnología", "Arte", "Cocina", "Videojuegos", "Mascotas", "Otro" };
            var interesesDb = await _context.Intereses.Select(i => i.NombreInteres).ToListAsync();
            var opcionesInteres = interesesPredefinidos.Union(interesesDb).Distinct().ToList();

            var generosPredefinidos = new List<string> { "Masculino", "Femenino", "Otro" };
            var generosDb = await _context.Generos.Select(g => g.NombreGenero).ToListAsync();
            var opcionesGenero = generosPredefinidos.Union(generosDb).Distinct().ToList();

            var carrerasPredefinidas = new List<string> { "Ingeniería", "Medicina", "Derecho", "Arquitectura", "Psicología", "Administración", "Contaduría", "Comunicación", "Educación", "Otra" };
            var carrerasDb = await _context.Carreras.Select(c => c.NombreCarrera).ToListAsync();
            var opcionesCarrera = carrerasPredefinidas.Union(carrerasDb).Distinct().ToList();

            // Editar nombre
            string nombre = AnsiConsole.Prompt(
                new TextPrompt<string>("Nombre [grey](ENTER para mantener: {0})[/]".Replace("{0}", usuario.Nombre))
                    .AllowEmpty());
            if (!string.IsNullOrWhiteSpace(nombre)) usuario.Nombre = nombre;

            // Editar edad
            string edadStr = AnsiConsole.Prompt(
                new TextPrompt<string>($"Edad [grey](ENTER para mantener: {usuario.Edad})[/]").AllowEmpty());
            if (int.TryParse(edadStr, out int nuevaEdad) && nuevaEdad >= 18 && nuevaEdad <= 100) usuario.Edad = nuevaEdad;

            // Editar género
            string genero = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Selecciona tu género [grey](ENTER para mantener: {usuario.Genero?.NombreGenero})[/]")
                    .AddChoices(opcionesGenero)
                    .AddChoices("Nuevo género", "Mantener actual")
            );
            if (genero == "Nuevo género")
            {
                string nuevoGenero = AnsiConsole.Prompt(new TextPrompt<string>("Ingrese el nuevo género:").AllowEmpty());
                if (!string.IsNullOrWhiteSpace(nuevoGenero))
                {
                    var generoDb = await _context.Generos.FirstOrDefaultAsync(g => g.NombreGenero == nuevoGenero);
                    if (generoDb == null)
                    {
                        generoDb = new Genero { NombreGenero = nuevoGenero };
                        _context.Generos.Add(generoDb);
                        await _context.SaveChangesAsync();
                    }
                    usuario.IdGenero = generoDb.IdGenero;
                }
            }
            else if (genero != "Mantener actual")
            {
                var generoDb = await _context.Generos.FirstOrDefaultAsync(g => g.NombreGenero == genero);
                if (generoDb != null) usuario.IdGenero = generoDb.IdGenero;
            }

            // Editar carrera
            string carrera = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Selecciona tu carrera [grey](ENTER para mantener: {usuario.Carrera?.NombreCarrera})[/]")
                    .AddChoices(opcionesCarrera)
                    .AddChoices("Nueva carrera", "Mantener actual")
            );
            if (carrera == "Nueva carrera")
            {
                string nuevaCarrera = AnsiConsole.Prompt(new TextPrompt<string>("Ingrese la nueva carrera:").AllowEmpty());
                if (!string.IsNullOrWhiteSpace(nuevaCarrera))
                {
                    var carreraDb = await _context.Carreras.FirstOrDefaultAsync(c => c.NombreCarrera == nuevaCarrera);
                    if (carreraDb == null)
                    {
                        carreraDb = new Carreras { NombreCarrera = nuevaCarrera };
                        _context.Carreras.Add(carreraDb);
                        await _context.SaveChangesAsync();
                    }
                    usuario.IdCarrera = carreraDb.IdCarrera;
                }
            }
            else if (carrera != "Mantener actual")
            {
                var carreraDb = await _context.Carreras.FirstOrDefaultAsync(c => c.NombreCarrera == carrera);
                if (carreraDb != null) usuario.IdCarrera = carreraDb.IdCarrera;
            }

            // Editar frase de perfil
            string frasePerfil = AnsiConsole.Prompt(
                new TextPrompt<string>($"Frase de perfil [grey](ENTER para mantener: {usuario.FrasePerfil})[/]").AllowEmpty());
            if (!string.IsNullOrWhiteSpace(frasePerfil)) usuario.FrasePerfil = frasePerfil;

            // Editar intereses
            var interesesActuales = usuario.UsuariosIntereses.Select(ui => ui.Interes?.NombreInteres ?? "").ToList();
            var seleccionados = new List<string>();
            var opcionesInteresEdit = new List<string>(opcionesInteres);
            while (true)
            {
                var seleccion = AnsiConsole.Prompt(
                    new Spectre.Console.MultiSelectionPrompt<string>()
                        .Title($"Selecciona tus intereses (ENTER para mantener los actuales: {string.Join(", ", interesesActuales)})")
                        .NotRequired()
                        .PageSize(10)
                        .MoreChoicesText("[grey](Desplázate para ver más intereses)[/]")
                        .InstructionsText("[grey](<espacio> para seleccionar, <enter> para continuar)[/]")
                        .AddChoices(opcionesInteresEdit)
                        .AddChoices("Mantener actuales", "Agregar nuevo")
                );
                if (seleccion.Contains("Agregar nuevo"))
                {
                    string nuevoInteres = AnsiConsole.Prompt(new TextPrompt<string>("Ingrese el nuevo interés:").AllowEmpty());
                    if (!string.IsNullOrWhiteSpace(nuevoInteres))
                    {
                        var interesDb = await _context.Intereses.FirstOrDefaultAsync(i => i.NombreInteres == nuevoInteres);
                        if (interesDb == null)
                        {
                            interesDb = new Intereses { NombreInteres = nuevoInteres };
                            _context.Intereses.Add(interesDb);
                            await _context.SaveChangesAsync();
                        }
                        if (!opcionesInteresEdit.Contains(nuevoInteres))
                            opcionesInteresEdit.Add(nuevoInteres);
                    }
                    // Repetir el ciclo para que el usuario pueda seleccionar el nuevo interés
                    continue;
                }
                else if (seleccion.Contains("Mantener actuales") || seleccion.Count == 0)
                {
                    // No cambios, mantener los intereses actuales
                    seleccionados = interesesActuales;
                }
                else
                {
                    seleccionados = seleccion.Where(s => s != "Mantener actuales" && s != "Agregar nuevo").ToList();
                }
                break;
            }
            // Actualizar intereses solo si hubo cambios
            if (seleccionados != null)
            {
                var usuarioIntereses = await _context.Set<UsuariosIntereses>().Where(ui => ui.IdUsuario == usuario.IdUsuario).ToListAsync();
                _context.Set<UsuariosIntereses>().RemoveRange(usuarioIntereses);
                foreach (var interesNombre in seleccionados.Distinct())
                {
                    var interesDb = await _context.Intereses.FirstOrDefaultAsync(i => i.NombreInteres == interesNombre);
                    if (interesDb != null)
                    {
                        var usuarioInteres = new UsuariosIntereses
                        {
                            IdUsuario = usuario.IdUsuario,
                            IdInteres = interesDb.IdInteres,
                            FechaRegistro = DateTime.Now
                        };
                        _context.Set<UsuariosIntereses>().Add(usuarioInteres);
                    }
                }
            }

            await _context.SaveChangesAsync();
            AnsiConsole.MarkupLine("[green]¡Datos actualizados correctamente![/]");
            return true;
        }

        // Implementación del método requerido por la interfaz
        public async Task<bool> EditarCuenta(int idUsuario, string nombre, string frasePerfil, string genero, string carrera, int edad, int idGenero, string intereses, string otraCarrera)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.UsuariosIntereses)
                .FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
            if (usuario == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(nombre)) usuario.Nombre = nombre;
            if (!string.IsNullOrWhiteSpace(frasePerfil)) usuario.FrasePerfil = frasePerfil;
            if (edad >= 18 && edad <= 100) usuario.Edad = edad;

            if (!string.IsNullOrWhiteSpace(genero))
            {
                var generoDb = await _context.Generos.FirstOrDefaultAsync(g => g.NombreGenero == genero);
                if (generoDb == null)
                {
                    generoDb = new Genero { NombreGenero = genero };
                    _context.Generos.Add(generoDb);
                    await _context.SaveChangesAsync();
                }
                usuario.IdGenero = generoDb.IdGenero;
            }
            else if (idGenero > 0)
            {
                usuario.IdGenero = idGenero;
            }

            if (!string.IsNullOrWhiteSpace(carrera))
            {
                var carreraDb = await _context.Carreras.FirstOrDefaultAsync(c => c.NombreCarrera == carrera);
                if (carreraDb == null)
                {
                    carreraDb = new Carreras { NombreCarrera = carrera };
                    _context.Carreras.Add(carreraDb);
                    await _context.SaveChangesAsync();
                }
                usuario.IdCarrera = carreraDb.IdCarrera;
            }
            else if (!string.IsNullOrWhiteSpace(otraCarrera))
            {
                var carreraDb = await _context.Carreras.FirstOrDefaultAsync(c => c.NombreCarrera == otraCarrera);
                if (carreraDb == null)
                {
                    carreraDb = new Carreras { NombreCarrera = otraCarrera };
                    _context.Carreras.Add(carreraDb);
                    await _context.SaveChangesAsync();
                }
                usuario.IdCarrera = carreraDb.IdCarrera;
            }

            if (!string.IsNullOrWhiteSpace(intereses))
            {
                var interesesList = intereses.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();
                var usuarioIntereses = await _context.Set<UsuariosIntereses>().Where(ui => ui.IdUsuario == usuario.IdUsuario).ToListAsync();
                _context.Set<UsuariosIntereses>().RemoveRange(usuarioIntereses);
                foreach (var interesNombre in interesesList)
                {
                    var interesDb = await _context.Intereses.FirstOrDefaultAsync(i => i.NombreInteres == interesNombre);
                    if (interesDb == null)
                    {
                        interesDb = new Intereses { NombreInteres = interesNombre };
                        _context.Intereses.Add(interesDb);
                        await _context.SaveChangesAsync();
                    }
                    var usuarioInteres = new UsuariosIntereses
                    {
                        IdUsuario = usuario.IdUsuario,
                        IdInteres = interesDb.IdInteres,
                        FechaRegistro = DateTime.Now
                    };
                    _context.Set<UsuariosIntereses>().Add(usuarioInteres);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}