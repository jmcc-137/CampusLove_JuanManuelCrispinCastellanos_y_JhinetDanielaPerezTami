namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
        // Métodos de negocio para usuarios (ejemplo)
        Task RegistrarUsuarioAsync(/* parámetros */);
        Task<bool> LoginAsync(string nombreUsuario, string contrasena);
        // Otros métodos según necesidades...
    }
}
