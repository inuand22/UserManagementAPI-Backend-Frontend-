using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionesEvento : Exception
    {
        public ExcepcionesEvento() { }

        public ExcepcionesEvento(string Mensaje) : base(Mensaje) { }

        public ExcepcionesEvento(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}
