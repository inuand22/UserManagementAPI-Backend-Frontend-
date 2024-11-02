using DTO;
using DTO.Mappers;
using Excepciones;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObjects;
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

        public void UpdateUsuario(UsuarioDTO dtoAltaUsuario)
        {
            Usuario user = MappersUsuarios.FromDTO(dtoAltaUsuario);
            Rol rol = RepositorioRol.FindById(2);
            user.Rol = rol;
            RepositorioUsuario.Update(user);
        }
    }
}

