namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<IEnumerable<Usuarios.Domain.Entities.Usuarios>> ObtenerUsuariosAsync();
        public Task<Usuarios.Domain.Entities.Usuarios> ObtenerUsuarioPorIdAsync(int id);
        public Task Add(CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios entity);
        public Task Remove(CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios entity);
        public Task Update(CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios entity);
        public Task SaveAsync();

    }
}
