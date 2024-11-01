using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionesRoles : Exception
    {
        public ExcepcionesRoles() { }

        public ExcepcionesRoles(string Mensaje) : base(Mensaje) { }

        public ExcepcionesRoles(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}
