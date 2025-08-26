using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.TiposInteracciones.Domain.Entities
{
    public class TiposInteracciones
    {
    public int IdTipoInteraccion { get; set; }
    public string NombreTipo { get; set; } = string.Empty;
    public virtual ICollection<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones> Interacciones { get; set; } = new List<CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Interacciones.Domain.Entities.Interacciones>();
    }
}