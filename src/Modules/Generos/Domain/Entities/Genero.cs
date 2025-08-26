using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Generos.Domain.Entities
{
    public class Genero
    {
        public int IdGenero { get; set; }
        public string NombreGenero { get; set; } = string.Empty;
        public virtual ICollection<Usuarios.Domain.Entities.Usuarios> Usuarios { get; set; } = new List<Usuarios.Domain.Entities.Usuarios>();
    }
}