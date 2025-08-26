using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Infrastructure.Repository;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS;
using Microsoft.EntityFrameworkCore;
var context = DbContextFactory.Create();
var mp = new MenuPrincipal();
var crearUsuarioService = new CrearUsuarioService(new UsuarioRepository(context), context);
crearUsuarioService.CrearUsuario().Wait();
