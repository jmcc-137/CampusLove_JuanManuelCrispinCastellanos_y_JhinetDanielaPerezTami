using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS;
using Microsoft.EntityFrameworkCore;
var context = DbContextFactory.Create();
var mp = new MenuPrincipal();
mp.MostrarMenuPrincipal();