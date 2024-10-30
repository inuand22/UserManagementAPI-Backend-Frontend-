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
    public class FindUserXId : IFindUsuarioXId
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public FindUserXId(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public ListadoUsuariosDTO DTOUsuario(int id)
        {
            Usuario user = RepositorioUsuario.FindById(id);
            if (user != null)
            {
                user.IdRol = user.Rol.Id;
                user.IdsTelefonos = user.Telefonos.Select(t => t.Id).ToList();
                user.Telefonos.Select(t => t.IdUsuario = user.Id).ToList();
                return MappersUsuarios.ToDTO(user);
            }
            return null;
        }
    }
}
