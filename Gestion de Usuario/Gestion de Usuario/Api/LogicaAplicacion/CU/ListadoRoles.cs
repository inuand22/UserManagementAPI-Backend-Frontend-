using DTO;
using DTO.Mappers;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class ListadoRoles : IListadoRoles
    {
        public IRepositorioRol RepositorioRol { get; set; }

        public ListadoRoles(IRepositorioRol repositorioRol)
        {
            RepositorioRol = repositorioRol;
        }

        public IEnumerable<RolesDTO> DTORoles()
        {
            return MappersRoles.TODTOs(RepositorioRol.FindAll().ToList());
        }
    }
}
