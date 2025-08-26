using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Shared.Helpers;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Infrastructure.Repository;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS;
using Microsoft.EntityFrameworkCore;



class Program
{
	static async Task Main(string[] args)
	{
		var menuInicio = new MenuInicio();
		await menuInicio.MostrarMenuInicio();

	}
}
