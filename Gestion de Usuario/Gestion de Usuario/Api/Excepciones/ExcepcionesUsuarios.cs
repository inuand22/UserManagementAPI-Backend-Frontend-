using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionesUsuarios : Exception
    {
        public ExcepcionesUsuarios() { }

        public ExcepcionesUsuarios(string Mensaje) : base(Mensaje) { }

        public ExcepcionesUsuarios(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}
