using Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        public CiUsuario Ci { get; set; }
        public bool EsMasculino { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public NombreUsuario Nombre { get; set; }
        public ApellidoUsuario Apellido { get; set; }
        public List<TelefonosUsuario> Telefonos { get; set; }

        [NotMapped]
        public List<int> IdsTelefonos { get; set; }

        public EmailUsuario Email { get; set; }
        public PasswordUsuario Pass { get; set; }

        public Rol? Rol { get; set; }

        [NotMapped]
        public int IdRol { get; set; }

        protected Usuario() { }

        public Usuario(CiUsuario ci, bool esMasculino,
            DateTime fechaNacimiento, NombreUsuario nombre,
            ApellidoUsuario apellido, EmailUsuario email, Rol rol, PasswordUsuario pass)
        {
            Ci = ci;
            EsMasculino = esMasculino;
            FechaNacimiento = fechaNacimiento;
            Nombre = nombre;
            Apellido = apellido;
            Telefonos = new List<TelefonosUsuario>();
            Email = email;
            Rol = rol;
            Pass = pass;
            Validate();
        }

        public Usuario(CiUsuario ci, bool esMasculino,
            DateTime fechaNacimiento, NombreUsuario nombre, ApellidoUsuario apellido,
            EmailUsuario email, int idRol, PasswordUsuario pass)
        {
            Ci = ci;
            EsMasculino = esMasculino;
            FechaNacimiento = fechaNacimiento;
            Nombre = nombre;
            Apellido = apellido;
            Telefonos = new List<TelefonosUsuario>();
            Email = email;
            IdRol = idRol;
            Pass = pass;
            Validate();
        }

        public void Validate()
        {
            if (FechaNacimiento > DateTime.Now)
            {
                throw new ExcepcionesTelefonosUsuario("La fecha de nacimiento no puede ser mayor a la fecha actual.");
            }

            int edad = DateTime.Now.Year - FechaNacimiento.Year;

            if (edad < 18)
            {
                throw new ExcepcionesTelefonosUsuario("El usuario debe ser mayor de 18 años.");
            }

            if (edad > 65)
            {
                throw new ExcepcionesTelefonosUsuario("El usuario no puede tener más de 65 años.");
            }
        }
    }
}
