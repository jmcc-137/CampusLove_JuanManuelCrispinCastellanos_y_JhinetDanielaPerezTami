using System;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services;
using Spectre.Console;
using Microsoft.EntityFrameworkCore;

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
                        var usuarioEditar = await context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == _nombreUsuario);
                        if (usuarioEditar != null)
                        {
                            var editarUsuarioService = new EditarUsuarioService(context);
                            await editarUsuarioService.EditarCuenta(usuarioEditar.IdUsuario);
                            AnsiConsole.MarkupLine("[grey]Presiona cualquier tecla para continuar...[/]");
                            Console.ReadKey();
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]No se encontró tu usuario. No se pudo editar la cuenta.[/]");
                            Console.ReadKey();
                        }
                        break;
                    case "[red]❤️ Ir a Matches[/]":
                        break;
                    case "[purple]📊 Ver estadísticas del sistema[/]":
                        break;
                    case "[darkorange]🗑️ Eliminar Cuenta[/]":
                        // Obtener el usuario por nombre de usuario
                        var usuarioEliminar = await context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == _nombreUsuario);
                        if (usuarioEliminar != null)
                        {
                            var eliminarCuentaService = new EliminarCuentaService(context);
                            var eliminado = await eliminarCuentaService.EliminarCuenta(usuarioEliminar.IdUsuario);
                            if (eliminado)
                            {
                                AnsiConsole.MarkupLine("[red]Tu cuenta ha sido eliminada exitosamente. Presiona cualquier tecla para continuar...[/]");
                                Console.ReadKey();
                                salir = true;
                            }
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]No se encontró tu usuario. No se pudo eliminar la cuenta.[/]");
                            Console.ReadKey();
                        }
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
