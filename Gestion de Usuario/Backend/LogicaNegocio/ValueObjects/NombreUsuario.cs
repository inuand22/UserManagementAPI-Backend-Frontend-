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
    public class NombreUsuario : IEquatable<NombreUsuario>, IValidable
    {
        public string Valor { get; set; }

        protected NombreUsuario() { }

        public NombreUsuario(string valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(NombreUsuario? other)
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
                throw new ExcepcionesTelefonosUsuario("El nombre no puede ser vacío");
            }

            if (Valor.Length < 3 || Valor.Length > 50)
            {
                throw new ExcepcionesTelefonosUsuario("El largo del nombre no puede ser menor a 3 ni mayor a 50");
            }
        }
    }
}
