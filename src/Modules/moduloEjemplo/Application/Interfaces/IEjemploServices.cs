using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.moduloEjemplo.Domain.Entities;


namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.moduloEjemplo.Application.Interfaces
{
    public interface IEjemploServices
    {
    Task<ejemplo?> GetCityById(int id);
    Task<IEnumerable<ejemplo?>> GetAllCities();
    Task AddCityAsync(ejemplo city);
    Task UpdateCityAsync(int id, ejemplo Nombre);
    Task RemoveCityAsync(int id);
    }
}