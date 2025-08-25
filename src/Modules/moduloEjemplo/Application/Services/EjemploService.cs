using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen.src.Modules.moduloEjemplo.Application.Interfaces;
using examen.src.Modules.moduloEjemplo.Domain.Entities;

namespace examen.src.Modules.moduloEjemplo.Application.Services
{
    public class EjemploService : IEjemploServices
    {
        private readonly IEjemploRepositiory _ejemploRepository;

        public EjemploService(IEjemploRepositiory ejemploRepository)
        {
            _ejemploRepository = ejemploRepository;
        }

        public Task AddCityAsync(ejemplo city)
        {
            throw new NotImplementedException();
        }

        public async Task AddEjemploAsync(ejemplo entity)
        {
            _ejemploRepository.Add(entity);
            await _ejemploRepository.SaveAsync();
        }

        public Task<IEnumerable<ejemplo?>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ejemplo?>> GetAllEjemplosAsync()
        {
            return await _ejemploRepository.GetAllAsync();
        }

        public Task<ejemplo?> GetCityById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ejemplo?> GetEjemploByIdAsync(int id)
        {
            return await _ejemploRepository.GetByIdAsync(id);
        }

        public Task RemoveCityAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveEjemploAsync(int id)
        {
            var entity = await _ejemploRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _ejemploRepository.Remove(entity);
                await _ejemploRepository.SaveAsync();
            }
        }

        public Task UpdateCityAsync(int id, ejemplo Nombre)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEjemploAsync(int id, string nuevoNombre)
        {
            var existingEntity = await _ejemploRepository.GetByIdAsync(id);
            if (existingEntity != null)
            {
                existingEntity.Nombre = nuevoNombre;
                _ejemploRepository.Update(existingEntity);
                await _ejemploRepository.SaveAsync();
            }
        }
    }
}