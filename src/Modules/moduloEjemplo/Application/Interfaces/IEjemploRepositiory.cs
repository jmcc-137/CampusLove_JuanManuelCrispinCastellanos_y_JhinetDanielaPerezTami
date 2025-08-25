using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen.src.Modules.moduloEjemplo.Domain.Entities;

namespace examen.src.Modules.moduloEjemplo.Application.Interfaces
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