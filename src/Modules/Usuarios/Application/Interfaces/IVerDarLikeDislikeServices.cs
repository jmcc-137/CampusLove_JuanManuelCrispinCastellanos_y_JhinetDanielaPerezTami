using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.src.Modules.Usuarios.Application.Interfaces
{
    public interface IVerDarLikeDislikeServices
    {
      Task<bool> VerDarLikeDislike(int idUsuarioOrigen, int idUsuarioDestino, int idTipoInteraccion);   
    }
}