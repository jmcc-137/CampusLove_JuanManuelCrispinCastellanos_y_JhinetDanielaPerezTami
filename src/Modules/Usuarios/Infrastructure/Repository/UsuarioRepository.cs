using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        internal readonly DbContext _context;

        public UsuarioRepository(DbContext context)
        {
            _context = context;
        }
        public Task CrearUsuarioAsync(/* parámetros */)
        {
            // Implementación de acceso a datos
            throw new NotImplementedException();
        }

        public Task<bool> ExisteUsuarioAsync(string nombreUsuario)
        {
            // Implementación de acceso a datos
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Entities.Usuarios>> ObtenerUsuariosAsync()
        {
            return await _context.Set<Domain.Entities.Usuarios>().ToListAsync();
        }

        public async Task<Domain.Entities.Usuarios> ObtenerUsuarioPorIdAsync(int id)
        {
            var usuario = await _context.Set<Domain.Entities.Usuarios>().FindAsync(id);
            if (usuario == null)
            {
                throw new InvalidOperationException($"Usuario con id {id} no encontrado.");
            }
            return usuario;
        }

        public async Task Add(Domain.Entities.Usuarios entity)
        {
            await _context.Set<Domain.Entities.Usuarios>().AddAsync(entity);
        }

        public async Task Remove(Domain.Entities.Usuarios entity)
        {
            _context.Set<Domain.Entities.Usuarios>().Remove(entity);
        }

    
        

        public async Task Update(Domain.Entities.Usuarios entity)
        {
            _context.Set<Domain.Entities.Usuarios>().Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
           
        }
    }
}
