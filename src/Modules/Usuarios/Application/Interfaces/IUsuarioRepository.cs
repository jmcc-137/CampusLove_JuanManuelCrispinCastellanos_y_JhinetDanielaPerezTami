namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        // Métodos de acceso a datos para usuarios
        Task CrearUsuarioAsync(/* parámetros */);
        Task<bool> ExisteUsuarioAsync(string nombreUsuario);
        // Otros métodos según necesidades...
    }
}
