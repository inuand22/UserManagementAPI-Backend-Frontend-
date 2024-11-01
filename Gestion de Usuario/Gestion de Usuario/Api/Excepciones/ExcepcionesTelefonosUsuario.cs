using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ExcepcionesTelefonosUsuario : Exception
    {
        public ExcepcionesTelefonosUsuario() { }

        public ExcepcionesTelefonosUsuario(string Mensaje) : base(Mensaje) { }

        public ExcepcionesTelefonosUsuario(string Mensaje, Exception innerException) : base(Mensaje, innerException) { }
    }
}
