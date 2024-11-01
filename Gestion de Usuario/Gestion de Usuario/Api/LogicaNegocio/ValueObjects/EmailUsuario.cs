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
    public class EmailUsuario : IEquatable<EmailUsuario>, IValidable
    {
        public string Valor { get; set; }

        protected EmailUsuario() { }

        public EmailUsuario(string valor)
        {
            Valor = valor;
            Validate();
        }

        public bool Equals(EmailUsuario? other)
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
                throw new ExcepcionesTelefonosUsuario("El email no puede ser vacío");
            }

            if (!Valor.Contains("@") || !Valor.Contains(".com"))
            {
                throw new ExcepcionesTelefonosUsuario("El email debe contar con un dominio");
            }

            if (Valor.Length < 3 || Valor.Length > 50)
            {
                throw new ExcepcionesTelefonosUsuario("El largo del email no puede ser menor a 3 ni mayor a 50");
            }
        }
    }
}
