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
    public class DescripcionEvento : IEquatable<DescripcionEvento>, IValidable
    {
        public string Valor { get; set; }
        public DescripcionEvento(string valor)
        {
            Valor = valor;
            Validate();
        }
        protected DescripcionEvento() { }

        public bool Equals(DescripcionEvento? other)
        {
            if (other != null)
            {
                return Valor == other.Valor;
            }
            return false;
        }

        public void Validate()
        {
            Valor = Valor.Trim();

            if (string.IsNullOrEmpty(Valor) || string.IsNullOrWhiteSpace(Valor))
            {
                throw new ExcepcionesEvento("La descripción no puede ser vacía");
            }
        }
    }
}
