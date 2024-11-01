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
    public class PasswordUsuario : IEquatable<PasswordUsuario>, IValidable
    {
        public string Valor { get; set; }

        protected PasswordUsuario() { }

        public PasswordUsuario(string valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(PasswordUsuario? other)
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
                throw new ExcepcionesTelefonosUsuario("La contraseña no puede ser vacía");
            }

            if (!Valor.Contains("@") && !Valor.Contains("!") && !Valor.Contains(".")
                && !Valor.Contains(",") && !Valor.Contains(";"))
            {
                throw new ExcepcionesTelefonosUsuario("La contraseña debe contar con un carácter especial");
            }

            if (Valor.Length < 8 || Valor.Length > 50)
            {
                throw new ExcepcionesTelefonosUsuario("El largo de la contraseña no puede ser menor a 8 ni mayor a 50");
            }
        }
    }
}
