using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class TipoTramite
    {
        public int Id { get; set; }
        public NombreTipoTramite Nombre { get; set; }
    }
}
