using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen.src.Modules.moduloEjemplo.Domain.Entities;

namespace examen.src.Modules.moduloEjemplo.Application.Interfaces
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