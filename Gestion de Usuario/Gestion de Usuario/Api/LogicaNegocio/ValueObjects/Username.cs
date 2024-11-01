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
    public class Username : IEquatable<Username>, IValidable
    {
        public string Valor { get; set; }

        protected Username() { }

        public Username(string valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(Username? other)
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
                throw new ExcepcionesTelefonosUsuario("El UserName no puede ser vacío");
            }            

            if (Valor.Length < 8 || Valor.Length > 20)
            {
                throw new ExcepcionesTelefonosUsuario("El largo de la UserName no puede ser menor a 8 ni mayor a 20");
            }
        }
    }
}
