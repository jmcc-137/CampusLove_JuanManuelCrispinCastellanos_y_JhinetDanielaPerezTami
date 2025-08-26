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
        public virtual ICollection<Usuarios.Domain.Entities.Usuarios> Usuarios { get; set; } = new List<Usuarios.Domain.Entities.Usuarios>();
    }
}