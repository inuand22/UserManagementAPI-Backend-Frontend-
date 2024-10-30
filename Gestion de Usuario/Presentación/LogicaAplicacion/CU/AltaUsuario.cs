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
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioRol RepositorioRol { get; set; }
        public AltaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            RepositorioRol = repositorioRol;
        }

        public void AltaUser(AltaUsuarioDTO dto)
        {
            Usuario user = MappersUsuarios.FromDTO(dto);
            Rol rol = RepositorioRol.FindById(dto.IdRol);
            if (rol != null)
            {
                user.Rol = rol;
                user.IdRol = user.Rol.Id;
                RepositorioUsuario.Add(user);
                dto.Id = user.Id;
            }
            else
            {
                throw new ExcepcionesRoles("No se encontró el Rol");
            }
        }
    }
}
