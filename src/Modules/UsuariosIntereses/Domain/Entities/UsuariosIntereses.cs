using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities
{
    public class UsuariosIntereses
    {
        public int IdUsuarioInteres { get; set; }
        public int IdUsuario { get; set; }
        public int IdInteres { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}