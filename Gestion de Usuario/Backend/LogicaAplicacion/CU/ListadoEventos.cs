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
    public class ListadoEventos : IListadoEve
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public ListadoEventos(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos()
        {
            return MappersEventos.TODTOs(RepositorioEvento.FindAll().ToList());
        }
    }
}
