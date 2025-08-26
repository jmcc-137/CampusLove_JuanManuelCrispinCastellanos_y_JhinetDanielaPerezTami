using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{
    using Microsoft.EntityFrameworkCore;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Context;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities;

    using Spectre.Console;
    public class EliminarCuentaService: IEliminarCuentaServices
    {
        private readonly AppDbContext _context;
        public EliminarCuentaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EliminarCuenta(int idUsuario)
        {
            var confirm = AnsiConsole.Confirm("[red]¿Estás seguro de que deseas eliminar tu cuenta? Esta acción no se puede deshacer.[/]");
            if (!confirm)
                return false;

            // Eliminar matches donde el usuario participa
            var matches = await _context.Matches.Where(m => m.IdUsuario1 == idUsuario || m.IdUsuario2 == idUsuario).ToListAsync();
            _context.Matches.RemoveRange(matches);

            // Eliminar intereses del usuario
            var usuariosIntereses = await _context.Set<UsuariosIntereses>().Where(ui => ui.IdUsuario == idUsuario).ToListAsync();
            _context.Set<UsuariosIntereses>().RemoveRange(usuariosIntereses);

            // Eliminar interacciones donde el usuario es origen o destino
            var interacciones = await _context.Set<Interacciones>().Where(i => i.IdUsuarioOrigen == idUsuario || i.IdUsuarioDestino == idUsuario).ToListAsync();
            _context.Set<Interacciones>().RemoveRange(interacciones);

            // Eliminar usuario
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}