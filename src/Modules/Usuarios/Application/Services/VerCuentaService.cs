using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{
    using Microsoft.EntityFrameworkCore;
    using Spectre.Console;
    using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities;

    public class VerCuentaService : IVerCuentaService
    {
        private readonly DbContext _context;
        public VerCuentaService(DbContext context)
        {
            _context = context;
        }

        public async Task VerCuenta(string nombreUsuario)
        {
            var usuario = await _context.Set<Usuarios>().FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
            if (usuario == null)
            {
                AnsiConsole.MarkupLine("[red]No se encontró información del usuario.[/]");
                return;
            }
            AnsiConsole.Write(new Panel($"[bold]Nombre:[/] {usuario.Nombre}\n[bold]Edad:[/] {usuario.Edad}\n[bold]Usuario:[/] {usuario.NombreUsuario}\n[bold]Frase Perfil:[/] {usuario.FrasePerfil}\n[bold]Créditos diarios:[/] {usuario.CreditosDiarios}\n[bold]Fecha registro:[/] {usuario.FechaRegistro:dd/MM/yyyy}")
                .Header("[cyan]Información de tu cuenta[/]")
                .BorderColor(Color.HotPink));
        }
    }
}