using System;
using System.Security.Cryptography;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuInicio : IMenuInicioServices
    {
        private async Task<string?> IngresarCuenta()
        {
            var context = CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers.DbContextFactory.Create();
            int intentos = 0;
            while (intentos < 3)
            {
                string nombreUsuario = Spectre.Console.AnsiConsole.Prompt(
                    new Spectre.Console.TextPrompt<string>("Ingrese su nombre de usuario:")
                        .PromptStyle("green"));
                Console.Write("Ingrese su contraseña: ");
                string contrasena = LeerContrasenaOculta();

                var usuario = await context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios>()
                    .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

                if (usuario != null)
                {
                    Spectre.Console.AnsiConsole.MarkupLine("[green]¡Ingreso exitoso![/]");
                    return nombreUsuario;
                }
                else
                {
                    intentos++;
                    AnsiConsole.Clear();
                    Spectre.Console.AnsiConsole.MarkupLine($"[red]Usuario o contraseña incorrectos. Intento {intentos}/3[/]");
                }
            }
            Spectre.Console.AnsiConsole.MarkupLine("[red]Demasiados intentos fallidos. El programa finalizará.[/]");
            Environment.Exit(0);
            return null;
        }

            private string LeerContrasenaOculta()
        {
            string contrasena = "";
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(true);
                if (tecla.Key != ConsoleKey.Backspace && tecla.Key != ConsoleKey.Enter)
                {
                    contrasena += tecla.KeyChar;
                    Console.Write("*");
                }
                else if (tecla.Key == ConsoleKey.Backspace && contrasena.Length > 0)
                {
                    contrasena = contrasena.Substring(0, contrasena.Length - 1);
                    Console.Write("\b \b");
                }
            } while (tecla.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return contrasena;
        }

    public async Task MostrarMenuInicio()
    {
            bool salir = false;
            while (!salir)
            {
                AnsiConsole.Clear();

                
                AnsiConsole.Write(
                    new FigletText("💖Campus Love 💖")
                        .Centered()
                        .Color(Color.HotPink));

                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]✨ Selecciona una opción de inicio ✨[/]")
                        .HighlightStyle("bold green")
                        .AddChoices(new[]
                        {
                            "[cyan]🔑 Ingresar cuenta[/]",
                            "[green]👤 Registrarse como nuevo usuario[/]",
                            "[red]🚪 Salir[/]"
                        }));

                switch (opcion)
                {
                    case "[cyan]🔑 Ingresar cuenta[/]":
                        var nombreUsuario = await IngresarCuenta();
                        if (!string.IsNullOrEmpty(nombreUsuario))
                        {
                           
                            var menuPrincipal = new MenuPrincipal(nombreUsuario);
                            await menuPrincipal.MostrarMenuPrincipal();
                        }
                        break;
                    case "[green]👤 Registrarse como nuevo usuario[/]":
                        var context = CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers.DbContextFactory.Create();
                        var usuarioRepository = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Infrastructure.Repository.UsuarioRepository(context);
                        var crearUsuarioService = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services.CrearUsuarioService(usuarioRepository, context);
                        await crearUsuarioService.CrearUsuario();
                        break;
                    case "[red]🚪 Salir[/]":
                        AnsiConsole.MarkupLine("[red]👋 Saliendo de Campus Love...[/]");
                        salir = true;
                        break;
                }
            }
        }

    }
}
