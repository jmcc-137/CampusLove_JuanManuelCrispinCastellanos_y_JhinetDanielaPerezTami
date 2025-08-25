using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.moduloEjemplo.Domain.Entities;


namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.moduloEjemplo.Application.Interfaces
{
    public interface IEjemploRepositiory
    {
    Task<ejemplo?> GetByIdAsync(int id);
    Task<IEnumerable<ejemplo?>> GetAllAsync();
    void Add(ejemplo entity);
    void Remove(ejemplo entity);
    void Update(ejemplo entity);
    Task SaveAsync();
    }
}