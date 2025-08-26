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
            // Opciones preestablecidas de género y carrera
            var generosPredefinidos = new List<string> { "Masculino", "Femenino", "Otro" };
            var carrerasPredefinidas = new List<string> { "Ingeniería", "Medicina", "Derecho", "Arquitectura", "Psicología", "Administración", "Contaduría", "Comunicación", "Educación", "Otra" };

            // Pedir datos al usuario y validar que no sean vacíos o nulos
            string nombre = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su nombre:")
                    .Validate(n => !string.IsNullOrWhiteSpace(n) ? ValidationResult.Success() : ValidationResult.Error("El nombre no puede estar vacío.")));

            int edad = AnsiConsole.Prompt(
                new TextPrompt<int>("Ingrese su edad:")
                    .Validate(e => e >= 18 && e <= 100 ? ValidationResult.Success() : ValidationResult.Error("Edad inválida. Debe estar entre 18 y 100.")));

            string genero = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione su género:")
                    .AddChoices(generosPredefinidos));

            string carrera = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Seleccione su carrera:")
                    .AddChoices(carrerasPredefinidas));

            string frasePerfil = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su frase de perfil:")
                    .Validate(f => !string.IsNullOrWhiteSpace(f) ? ValidationResult.Success() : ValidationResult.Error("La frase de perfil no puede estar vacía.")));

            string nombreUsuario = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su nombre de usuario:")
                    .Validate(u => !string.IsNullOrWhiteSpace(u) ? ValidationResult.Success() : ValidationResult.Error("El nombre de usuario no puede estar vacío.")));

            string contrasenaPlano = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su contraseña:")
                    .Validate(p => !string.IsNullOrWhiteSpace(p) ? ValidationResult.Success() : ValidationResult.Error("La contraseña no puede estar vacía.")));
            string contrasena = HashSHA256(contrasenaPlano);

            // Buscar o crear el género seleccionado
            var generoDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero>()
                .FirstOrDefaultAsync(g => g.NombreGenero == genero);
            if (generoDb == null)
            {
                generoDb = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero
                {
                    NombreGenero = genero
                };
                _context.Add(generoDb);
                await _context.SaveChangesAsync();
            }
            int idGenero = generoDb.IdGenero;

            // Buscar o crear la carrera seleccionada
            var carreraDb = await _context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras>()
                .FirstOrDefaultAsync(c => c.NombreCarrera == carrera);
            if (carreraDb == null)
            {
                carreraDb = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras
                {
                    NombreCarrera = carrera
                };
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

        // Función local para hashear contraseña
        string HashSHA256(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

            await _usuarioRepository.Add(usuario);
            await _usuarioRepository.SaveAsync();

            AnsiConsole.MarkupLine("[green]Usuario registrado correctamente![/]");
        }


    }
}