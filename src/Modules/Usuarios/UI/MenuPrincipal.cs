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
                        // Inicializar tipos de interacción si no existen
                        if (!await context.TiposInteracciones.AnyAsync())
                        {
                            context.TiposInteracciones.Add(new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities.TiposInteracciones { NombreTipo = "LIKE" });
                            context.TiposInteracciones.Add(new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities.TiposInteracciones { NombreTipo = "DISLIKE" });
                            await context.SaveChangesAsync();
                        }
                        // Mostrar perfiles y dar Like/Dislike
                        var usuarioActual = await context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == _nombreUsuario);
                        if (usuarioActual == null)
                        {
                            AnsiConsole.MarkupLine("[red]No se encontró tu usuario. No se puede mostrar perfiles.[/]");
                            Console.ReadKey();
                            break;
                        }

                        // Obtener todos los usuarios excepto el actual y que estén activos
                        var usuarios = await context.Usuarios
                            .Where(u => u.IdUsuario != usuarioActual.IdUsuario && u.Activo)
                            .Include(u => u.UsuariosIntereses)
                                .ThenInclude(ui => ui.Interes)
                            .ToListAsync();

                        // Obtener los tipos de interacción (LIKE y DISLIKE)
                        var tipoLike = await context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities.TiposInteracciones>()
                            .FirstOrDefaultAsync(t => t.NombreTipo.ToUpper() == "LIKE");
                        var tipoDislike = await context.Set<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities.TiposInteracciones>()
                            .FirstOrDefaultAsync(t => t.NombreTipo.ToUpper() == "DISLIKE");
                        if (tipoLike == null || tipoDislike == null)
                        {
                            AnsiConsole.MarkupLine("[red]No se encontraron los tipos de interacción LIKE/DISLIKE en la base de datos.[/]");
                            Console.ReadKey();
                            break;
                        }

                        CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces.IVerDarLikeDislikeServices verDarLikeDislikeService =
                            new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services.VerDarLikeDislikeService(context);
                        int idx = 0;
                        while (idx < usuarios.Count)
                        {
                            var u = usuarios[idx];
                            AnsiConsole.Clear();
                            CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services.VerDarLikeDislikeService.MostrarPerfilUsuario(u);

                            var accion = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                    .Title("[yellow]¿Qué deseas hacer con este perfil?[/]")
                                    .AddChoices(new[] { "💖 Corazón (Like)", "❌ X (Dislike)", "🚪 Salir" })
                            );

                            if (accion == "🚪 Salir")
                                break;

                            int idTipoInteraccion = accion == "💖 Corazón (Like)" ? tipoLike.IdTipoInteraccion : tipoDislike.IdTipoInteraccion;
                            // Registrar la interacción
                            await verDarLikeDislikeService.VerDarLikeDislike(usuarioActual.IdUsuario, u.IdUsuario, idTipoInteraccion);

                            // Preguntar si quiere seguir viendo perfiles
                            var seguir = AnsiConsole.Confirm("¿Deseas ver el siguiente perfil?");
                            if (!seguir)
                                break;
                            idx++;
                        }
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
