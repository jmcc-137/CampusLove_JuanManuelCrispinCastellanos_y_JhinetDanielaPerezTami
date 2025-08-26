using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{
    public class CrearUsuarioService : ICrearUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly DbContext _context;

        public CrearUsuarioService(IUsuarioRepository usuarioRepository, DbContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        public async Task CrearUsuario()
        {
            // Intereses preestablecidos
            var interesesPredefinidos = new List<string> { "Deportes", "Música", "Cine", "Lectura", "Viajes", "Tecnología", "Arte", "Cocina", "Videojuegos", "Mascotas", "Otro" };
            var interesesSeleccionados = AnsiConsole.Prompt(
                new Spectre.Console.MultiSelectionPrompt<string>()
                    .Title("Selecciona tus intereses (usa espacio para seleccionar, enter para continuar):")
                    .NotRequired()
                    .PageSize(10)
                    .MoreChoicesText("[grey](Desplázate para ver más intereses)[/]")
                    .InstructionsText("[grey](<espacio> para seleccionar, <enter> para continuar)[/]")
                    .AddChoices(interesesPredefinidos)
            );
            // Opciones predefinidas
            var generosPredefinidos = new List<string> { "Masculino", "Femenino", "Otro" };
            var carrerasPredefinidas = new List<string> { "Ingeniería", "Medicina", "Derecho", "Arquitectura", "Psicología", "Administración", "Contaduría", "Comunicación", "Educación", "Otra" };
            var generosDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero>().Select(g => g.NombreGenero).ToListAsync();
            var carrerasDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras>().Select(c => c.NombreCarrera).ToListAsync();
            var opcionesGenero = generosPredefinidos.Union(generosDb).Distinct().ToList();
            var opcionesCarrera = carrerasPredefinidas.Union(carrerasDb).Distinct().ToList();
            // Filtrar corchetes para evitar error de markup
            opcionesGenero = opcionesGenero.Select(g => g.Replace("[", "(").Replace("]", ")")).ToList();
            opcionesCarrera = opcionesCarrera.Select(c => c.Replace("[", "(").Replace("]", ")")).ToList();

            // Pedir datos al usuario y validar que no sean vacíos o nulos
            string nombre = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su nombre:")
                    .Validate(n => !string.IsNullOrWhiteSpace(n) ? ValidationResult.Success() : ValidationResult.Error("El nombre no puede estar vacío.")));

            int edad = AnsiConsole.Prompt(
                new TextPrompt<int>("Ingrese su edad:")
                    .Validate(e => e >= 18 && e <= 100 ? ValidationResult.Success() : ValidationResult.Error("Edad inválida. Debe estar entre 18 y 100.")));

            string genero = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione su género (o escriba uno nuevo):")
                    .AddChoices(opcionesGenero)
                    .AddChoices("Nuevo género")
            );
            if (genero == "Nuevo género")
            {
                genero = AnsiConsole.Prompt(new TextPrompt<string>("Ingrese el nuevo género:").Validate(g => !string.IsNullOrWhiteSpace(g) ? ValidationResult.Success() : ValidationResult.Error("El género no puede estar vacío.")));
            }

            string carrera = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione su carrera (o escriba una nueva):")
                    .AddChoices(opcionesCarrera)
                    .AddChoices("Nueva carrera")
            );
            if (carrera == "Nueva carrera")
            {
                carrera = AnsiConsole.Prompt(new TextPrompt<string>("Ingrese la nueva carrera:").Validate(c => !string.IsNullOrWhiteSpace(c) ? ValidationResult.Success() : ValidationResult.Error("La carrera no puede estar vacía.")));
            }

            string frasePerfil = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su frase de perfil:")
                    .Validate(f => !string.IsNullOrWhiteSpace(f) ? ValidationResult.Success() : ValidationResult.Error("La frase de perfil no puede estar vacía.")));

            string nombreUsuario = "";
            while (true)
            {
                nombreUsuario = AnsiConsole.Prompt(
                    new TextPrompt<string>("Ingrese su nombre de usuario:")
                        .Validate(u => !string.IsNullOrWhiteSpace(u) ? ValidationResult.Success() : ValidationResult.Error("El nombre de usuario no puede estar vacío.")));
                var existe = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios>().AnyAsync(u => u.NombreUsuario == nombreUsuario);
                if (!existe)
                    break;
                AnsiConsole.MarkupLine($"[red]El nombre de usuario '{nombreUsuario}' ya está en uso. Intenta con otro.[/]");
            }

            string contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su contraseña:")
                    .Validate(p => !string.IsNullOrWhiteSpace(p) ? ValidationResult.Success() : ValidationResult.Error("La contraseña no puede estar vacía.")));

            // Buscar o crear género
            var generoDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero>().FirstOrDefaultAsync(g => g.NombreGenero == genero);
            if (generoDb == null)
            {
                generoDb = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero { NombreGenero = genero };
                _context.Add(generoDb);
                await _context.SaveChangesAsync();
            }
            int idGenero = generoDb.IdGenero;

            // Buscar o crear carrera
            var carreraDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras>().FirstOrDefaultAsync(c => c.NombreCarrera == carrera);
            if (carreraDb == null)
            {
                carreraDb = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras { NombreCarrera = carrera };
                _context.Add(carreraDb);
                await _context.SaveChangesAsync();
            }
            int idCarrera = carreraDb.IdCarrera;

            // Crear entidad usuario
            var usuario = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios
            {
                Nombre = nombre,
                Edad = edad,
                IdGenero = idGenero,
                IdCarrera = idCarrera,
                FrasePerfil = frasePerfil,
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                CreditosDiarios = 10,
                FechaUltimaInteraccion = DateTime.Now,
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            await _usuarioRepository.Add(usuario);
            await _usuarioRepository.SaveAsync();

            // Guardar intereses seleccionados
            if (interesesSeleccionados.Count > 0)
            {
                var usuarioDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios>()
                    .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
                foreach (var interesNombre in interesesSeleccionados)
                {
                    // Buscar o crear el interés
                    var interes = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Intereses.Domain.Entities.Intereses>()
                        .FirstOrDefaultAsync(i => i.NombreInteres == interesNombre);
                    if (interes == null)
                    {
                        interes = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Intereses.Domain.Entities.Intereses
                        {
                            NombreInteres = interesNombre
                        };
                        _context.Add(interes);
                        await _context.SaveChangesAsync();
                    }
                    if (usuarioDb != null && interes != null)
                    {
                        var usuarioInteres = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses
                        {
                            IdUsuario = usuarioDb.IdUsuario,
                            IdInteres = interes.IdInteres,
                            FechaRegistro = DateTime.Now
                        };
                        _context.Add(usuarioInteres);
                    }
                }
                await _context.SaveChangesAsync();
            }

            AnsiConsole.MarkupLine("[green]Usuario registrado correctamente![/]");
        }


    }
}