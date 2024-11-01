using DTO;
using DTO.Mappers;
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
    public class ListaUsuarios : IListadoUsuarios
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public ListaUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<UsuarioDTO> DTOUsuarios()
        {
            IEnumerable<Usuario> user = RepositorioUsuario.FindAll();
            foreach (Usuario usuario in user)
            {
                usuario.IdRol = usuario.Rol.Id;
            }
            return MappersUsuarios.TODTOs(user.ToList());
        }
    }
}
