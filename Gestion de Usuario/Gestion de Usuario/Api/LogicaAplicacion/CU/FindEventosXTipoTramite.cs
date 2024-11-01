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
    public class FindEventosXTipoTramite : IFindEveXTipoTramite
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventosXTipoTramite(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos(ETipoTramite enumTipoTramite)
        {
            IEnumerable<EventosDTO> dto = MappersEventos.TODTOs(RepositorioEvento.FindXTipoTramite(enumTipoTramite).ToList());
            return dto;
        }
    }
}
