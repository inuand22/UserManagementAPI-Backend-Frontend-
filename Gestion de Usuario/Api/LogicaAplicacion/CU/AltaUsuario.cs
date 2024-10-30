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
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioRol RepositorioRol { get; set; }
        public AltaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            RepositorioUsuario = repositorioUsuario;
            RepositorioRol = repositorioRol;
        }

        public void AltaUser(UsuarioDTO dto)
        {
            Usuario user = MappersUsuarios.FromDTO(dto);
            Rol rol = RepositorioRol.FindById(2);           
            user.Rol = rol;
            RepositorioUsuario.Add(user);
        }
    }
}
