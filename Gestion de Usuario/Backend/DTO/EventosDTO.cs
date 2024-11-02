using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EventosDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEvento { get; set; }
        public int IdTramite { get; set; }
    }
}
