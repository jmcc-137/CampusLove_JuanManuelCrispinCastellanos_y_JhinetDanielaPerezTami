using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{

    public class VerDarLikeDislikeService : IVerDarLikeDislikeServices
    {
        private readonly CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Context.AppDbContext _context;
        public VerDarLikeDislikeService(CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Context.AppDbContext context)
        {
            _context = context;
        }

        public static void MostrarPerfilUsuario(CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios usuario)
        {
            var intereses = usuario.UsuariosIntereses.Select(ui => ui.Interes?.NombreInteres).Where(i => !string.IsNullOrWhiteSpace(i)).ToList();
            var tabla = new Spectre.Console.Table();
            tabla.Border = Spectre.Console.TableBorder.Rounded;
            tabla.AddColumn("[bold yellow]Nombre[/]");
            tabla.AddColumn("[bold]Edad[/]");
            tabla.AddColumn("[bold]Frase de perfil[/]");
            tabla.AddColumn("[bold]Intereses[/]");
            tabla.AddRow(
                $"[aqua]{usuario.Nombre}[/]",
                $"[white]{usuario.Edad}[/]",
                $"[italic grey]{usuario.FrasePerfil}[/]",
                intereses.Count > 0 ? $"[green]{string.Join(", ", intereses)}[/]" : "[grey]Sin intereses[/]"
            );
            Spectre.Console.AnsiConsole.Write(tabla);
        }

        public async Task<bool> VerDarLikeDislike(int idUsuarioOrigen, int idUsuarioDestino, int idTipoInteraccion)
        {
            var usuarioOrigen = await _context.Usuarios.FindAsync(idUsuarioOrigen);
            var usuarioDestino = await _context.Usuarios.FindAsync(idUsuarioDestino);
            if (usuarioOrigen == null || usuarioDestino == null || !usuarioOrigen.Activo || !usuarioDestino.Activo)
                return false;

            var tipoInteraccion = await _context.TiposInteracciones.FindAsync(idTipoInteraccion);
            if (tipoInteraccion == null)
                return false;

            var hoy = DateTime.Today;
            // Solo limitar likes, no dislikes
            bool esLike = tipoInteraccion.NombreTipo.ToUpper() == "LIKE";
            if (esLike)
            {
                int likesHoy = await _context.Interacciones.CountAsync(i =>
                    i.IdUsuarioOrigen == idUsuarioOrigen &&
                    i.IdTipoInteraccion == tipoInteraccion.IdTipoInteraccion &&
                    i.FechaInteraccion.Date == hoy);
                if (likesHoy >= usuarioOrigen.CreditosDiarios)
                {
                    AnsiConsole.MarkupLine($"[red]Has alcanzado tu límite diario de likes ({usuarioOrigen.CreditosDiarios}). Intenta mañana.[/]");
                    return false;
                }
            }

            var existe = await _context.Interacciones.AnyAsync(i =>
                i.IdUsuarioOrigen == idUsuarioOrigen &&
                i.IdUsuarioDestino == idUsuarioDestino &&
                i.FechaInteraccion.Date == hoy);
            if (existe)
                return false;

            var interaccion = new CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones
            {
                IdUsuarioOrigen = idUsuarioOrigen,
                IdUsuarioDestino = idUsuarioDestino,
                IdTipoInteraccion = idTipoInteraccion,
                FechaInteraccion = DateTime.Now
            };
            _context.Interacciones.Add(interaccion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}