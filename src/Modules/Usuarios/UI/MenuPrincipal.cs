using System;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services;
using Spectre.Console;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuPrincipal: IMenuPrincipalServices
    {
        private readonly string _nombreUsuario;
        public MenuPrincipal(string nombreUsuario)
        {
            _nombreUsuario = nombreUsuario;
        }
        public async Task MostrarMenuPrincipal()
        {
            bool salir = false;
            while (!salir)
            {
                AnsiConsole.Clear();

                // Título con Figlet estilizado
                AnsiConsole.Write(
                    new FigletText("💖 Campus Love 💖")
                        .Centered()
                        .Color(Color.HotPink));

                // Menú con colores y emojis
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]✨ ¿Qué deseas hacer? ✨[/]")
                        .HighlightStyle("bold green")
                        .AddChoices(new[]
                        {
                            "[cyan]👤 Ver cuenta[/]",
                            "[green]🔍 Ver perfiles y dar Like/Dislike[/]",
                            "[yellow]✏️ Editar Cuenta[/]",
                            "[blue]📝 Añadir Información Personal[/]",
                            "[red]❤️ Ir a Matches[/]",
                            "[purple]📊 Ver estadísticas del sistema[/]",
                            "[darkorange]🗑️ Eliminar Cuenta[/]",
                            "[grey]🚪 Salir[/]"
                        }));
                var context = CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers.DbContextFactory.Create();
                var verCuentaService = new VerCuentaService(context);

                switch (opcion)
                {
                    case "[cyan]👤 Ver cuenta[/]":
                        await verCuentaService.VerCuenta(_nombreUsuario);
                        AnsiConsole.MarkupLine("[grey]Presiona cualquier tecla para continuar...[/]");
                        Console.ReadKey();
                        break;
                    case "[green]🔍 Ver perfiles y dar Like/Dislike[/]":
                        break;
                    case "[yellow]✏️ Editar Cuenta[/]":

                        break;
                    case "[blue]📝 Añadir Información Personal[/]":
                        break;
                    case "[red]❤️ Ir a Matches[/]":

                        break;
                    case "[purple]📊 Ver estadísticas del sistema[/]":
                        break;
                    case "[darkorange]🗑️ Eliminar Cuenta[/]":
                        break;
                    case "[grey]🚪 Salir[/]":
                        AnsiConsole.MarkupLine("[red]👋 Saliendo de Campus Love...[/]");

                        salir = true;
                        break;
                }
            }
        }


    }
}
