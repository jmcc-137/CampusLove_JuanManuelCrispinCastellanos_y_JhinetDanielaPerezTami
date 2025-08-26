using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Matches.Domain.Entities
{
    public class Matches
    {
        public int IdMatch { get; set; }
        public int IdUsuario1 { get; set; }
        public int IdUsuario2 { get; set; }
        public DateTime FechaMatch { get; set; }
        public bool Activo { get; set; }

        public virtual CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios? Usuario1 { get; set; }
        public virtual  CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Domain.Entities.Usuarios? Usuario2 { get; set; }
    }
}