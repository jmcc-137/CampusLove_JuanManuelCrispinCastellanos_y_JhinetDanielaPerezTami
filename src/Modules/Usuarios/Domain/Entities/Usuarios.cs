using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public int IdGenero { get; set; }
        public int IdCarrera { get; set; }
        public string FrasePerfil { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public int CreditosDiarios { get; set; }
        public DateTime FechaUltimaInteraccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public virtual CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities.Genero? Genero { get; set; }
        public virtual CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities.Carreras? Carrera { get; set; }
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses> UsuariosIntereses { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses>();
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones> InteraccionesOrigen { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones>();
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones> InteraccionesDestino { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones>();
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities.Matches> Matches1 { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities.Matches>();
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities.Matches> Matches2 { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities.Matches>();
    }
}
