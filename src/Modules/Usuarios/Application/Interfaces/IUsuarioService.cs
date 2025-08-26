namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
 
        Task RegistrarUsuarioAsync(Domain.Entities.Usuarios usuario);
        Task ActualizarUsuarioAsync(Domain.Entities.Usuarios usuario);
        Task EliminarUsuarioAsync(int id);
        Task<IEnumerable<Domain.Entities.Usuarios>> ObtenerTodosLosUsuariosAsync();
    }
}
