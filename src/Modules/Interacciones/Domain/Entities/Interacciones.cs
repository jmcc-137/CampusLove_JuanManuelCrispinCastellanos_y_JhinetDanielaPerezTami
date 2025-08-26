using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities
{
    public class Interacciones
    {
        public int IdInteraccion { get; set; }
        public int IdUsuarioOrigen { get; set; }
        public int IdUsuarioDestino { get; set; }
    public int IdTipoInteraccion { get; set; }
    public DateTime FechaInteraccion { get; set; }

    public virtual Usuarios.Domain.Entities.Usuarios? UsuarioOrigen { get; set; }
    public virtual Usuarios.Domain.Entities.Usuarios? UsuarioDestino { get; set; }
    public virtual TiposInteracciones.Domain.Entities.TiposInteracciones? TipoInteraccion { get; set; }
    }
}