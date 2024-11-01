using DTO;
using DTO.Mappers;
using Excepciones;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class FindUserByMail : IFindUserXMail
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioRol RepositorioRol { get; set; }

        public FindUserByMail(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            RepositorioRol = repositorioRol;
        }

        public UsuarioDTO FindXMail(string email)
        {
            email = email.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                throw new ExcepcionesUsuarios("El email no puede ser vacío");
            }

            Usuario user = RepositorioUsuario.FindByEmail(email);

            if (user == null)
            {
                throw new ExcepcionesUsuarios("Usuario no encontrado");
            }

            return MappersUsuarios.ToDTO(user);
        }
    }
}
