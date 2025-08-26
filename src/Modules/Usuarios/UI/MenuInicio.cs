using System;
using Spectre.Console;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuInicio
    {
        public void MostrarMenuInicio()
        {
            bool salir = false;
            while (!salir)
            {
                AnsiConsole.Clear();

                // Título bonito
                AnsiConsole.Write(
                    new FigletText("💖 Campus Love 💖")
                        .Centered()
                        .Color(Color.HotPink));

                // Menú con emojis y colores
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
                        // Lógica para ingresar cuenta
                        pausa();
                        break;
                    case "[green]👤 Registrarse como nuevo usuario[/]":
                        // Lógica para crear cuenta
                        pausa();
                        break;
                    case "[red]🚪 Salir[/]":
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
