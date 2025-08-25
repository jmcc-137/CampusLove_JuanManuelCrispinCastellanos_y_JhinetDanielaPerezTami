using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examen.src.Modules.Usuario.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;
    }
}