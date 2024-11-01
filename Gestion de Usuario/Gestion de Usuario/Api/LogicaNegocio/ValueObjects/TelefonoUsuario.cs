using Excepciones;
using LogicaNegocio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class TelefonoUsuario : IEquatable<TelefonoUsuario>, IValidable
    {
        public int Valor { get; set; }

        protected TelefonoUsuario() { }

        public TelefonoUsuario(int valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(TelefonoUsuario? other)
        {
            if (other != null)
            {
                return Valor == other.Valor;
            }
            return false;
        }

        public void Validate()
        {
            if(Valor == null)
            {
                throw new ExcepcionesUsuarios("El Teléfono no puede ser vacío");
            }
            if(Valor == 0)
            {
                throw new ExcepcionesUsuarios("El Teléfono no puede ser cero");
            }
            if(Valor <= 0)
            {
                throw new ExcepcionesUsuarios("EL Teléfono no puede ser un menor o igual a cero");
            }
        }
    }
}
