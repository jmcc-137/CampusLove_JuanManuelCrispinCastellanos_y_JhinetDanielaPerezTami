using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Intereses.Domain.Entities
{
    public class Intereses
    {
        public int IdInteres { get; set; }
        public string NombreInteres { get; set; } = string.Empty;
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses> UsuariosIntereses { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.UsuariosIntereses.Domain.Entities.UsuariosIntereses>();
    }
}