using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Carreras.Domain.Entities
{
    public class Carreras
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; } = string.Empty;
        public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios> Usuarios { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios>();
    }
}