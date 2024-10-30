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
    public class UpdateUser : IUpdateUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioRol RepositorioRol { get; set; }

        public UpdateUser(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            RepositorioRol = repositorioRol;
        }

        public void UpdateUsuario(AltaUsuarioDTO dtoAltaUsuario)
        {
            Usuario user = MappersUsuarios.FromDTO(dtoAltaUsuario);
            Rol rol = RepositorioRol.FindById(dtoAltaUsuario.IdRol);
            if (rol != null)
            {
                user.Rol = rol;
                user.IdRol = user.Rol.Id;
                RepositorioUsuario.Update(user);
                dtoAltaUsuario.Id = user.Id;
            }
            else
            {
                throw new ExcepcionesRoles("No se encontró el Rol");
            }
        }
    }
}

