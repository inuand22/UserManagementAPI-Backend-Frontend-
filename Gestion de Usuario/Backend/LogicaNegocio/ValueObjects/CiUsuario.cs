using Excepciones;
using LogicaNegocio.InterfacesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class CiUsuario : IEquatable<CiUsuario>, IValidable
    {
        public string Valor { get; set; }

        protected CiUsuario() { }

        public CiUsuario(string valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(CiUsuario? other)
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

            if (Valor == "" || Valor == null || string.IsNullOrEmpty(Valor))
            {
                throw new ExcepcionesTelefonosUsuario("La Cedula de Identidad no puede ser vacía");
            }

            if (Valor.Length != 8)
            {
                throw new ExcepcionesTelefonosUsuario("El largo de la Cedula de Identidad no puede ser diferente a 8");
            }
        }
    }
}
