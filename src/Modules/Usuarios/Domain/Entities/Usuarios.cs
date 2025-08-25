using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities
{
    public class Usuarios
    {
        public int IdUsuarios { get; set; }
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

        







    }
}