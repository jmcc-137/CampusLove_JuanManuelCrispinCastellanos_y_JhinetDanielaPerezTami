using CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task RegistrarUsuarioAsync(Domain.Entities.Usuarios usuario)
        {
            await _usuarioRepository.Add(usuario);
            await _usuarioRepository.SaveAsync();
        }

        public async Task ActualizarUsuarioAsync(Domain.Entities.Usuarios usuario)
        {
            await _usuarioRepository.Update(usuario);
            await _usuarioRepository.SaveAsync();
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorIdAsync(id);
            if (usuario != null)
            {
                await _usuarioRepository.Remove(usuario);
                await _usuarioRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<Domain.Entities.Usuarios>> ObtenerTodosLosUsuariosAsync()
        {
            return await _usuarioRepository.ObtenerUsuariosAsync();
        }
    }
}
