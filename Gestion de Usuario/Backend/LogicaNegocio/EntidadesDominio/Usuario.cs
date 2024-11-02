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
    public class Usuario
    {
        public int Id { get; set; }
        public CiUsuario Ci { get; set; }
        public NombreUsuario Nombre { get; set; }
        public ApellidoUsuario Apellido { get; set; }
        public TelefonoUsuario Telefono { get; set; }
        public EmailUsuario Email { get; set; }
        public PasswordUsuario Pass { get; set; }

        public List<Evento> Eventos { get; set; }

        [NotMapped]
        public List<int> IdsEventos { get; set; }

        public Rol? Rol { get; set; }

        [NotMapped]
        public int IdRol { get; set; }

        protected Usuario() { }

        public Usuario(CiUsuario ci, NombreUsuario nombre,
            ApellidoUsuario apellido, TelefonoUsuario telefono, EmailUsuario email, Rol rol, PasswordUsuario pass)
        {
            Ci = ci;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Rol = rol;
            Pass = pass;
            Eventos = new List<Evento>();
        }

        public Usuario(CiUsuario ci, NombreUsuario nombre, ApellidoUsuario apellido,
            EmailUsuario email, TelefonoUsuario telefono, int idRol, PasswordUsuario pass)
        {
            Ci = ci;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            IdRol = idRol;
            Pass = pass;
            IdsEventos = new List<int>();
        }
    }
}
