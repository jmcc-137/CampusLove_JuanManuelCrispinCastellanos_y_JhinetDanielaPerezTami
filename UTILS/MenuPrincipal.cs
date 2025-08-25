using System;
using Spectre.Console;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuPrincipal
    {
        public void MostrarMenuPrincipal()
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

                switch (opcion)
                {
                    case "[cyan]👤 Ver cuenta[/]":
                        pausa();
                        break;
                    case "[green]🔍 Ver perfiles y dar Like/Dislike[/]":
                        pausa();
                        break;
                    case "[yellow]✏️ Editar Cuenta[/]":
                        pausa();
                        break;
                    case "[blue]📝 Añadir Información Personal[/]":
                        pausa();
                        break;
                    case "[red]❤️ Ir a Matches[/]":
                        pausa();
                        break;
                    case "[purple]📊 Ver estadísticas del sistema[/]":
                        pausa();
                        break;
                    case "[darkorange]🗑️ Eliminar Cuenta[/]":
                        pausa();
                        break;
                    case "[grey]🚪 Salir[/]":
                        AnsiConsole.MarkupLine("[red]👋 Saliendo de Campus Love...[/]");
                        pausa();
                        salir = true;
                        break;
                }
            }
        }

        static void pausa()
        {
            AnsiConsole.MarkupLine("[grey]\nPresiona una tecla para continuar...[/]");
            Console.ReadKey();
        }
    }
}
