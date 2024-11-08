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
    public class FindEventosXFecha : IFindEveXFecha
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventosXFecha(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos(DateTime fecha1)
        {
            if (fecha1 != null)
            {
                IEnumerable<EventosDTO> dto = MappersEventos.TODTOs(RepositorioEvento.FindXFecha(fecha1).ToList());
                return dto;
            }
            throw new ExcepcionesEvento("La descripción no puede ser vacía");
        }

        public IEnumerable<EventosDTO> GetEventosFuturos()
        {
            List<Evento> eventos = RepositorioEvento.FindEventoFuturo().ToList();
            if (eventos == null)
            {
                throw new ExcepcionesEvento("No se ha encontrado ningún evento");
            }
            List<EventosDTO> dto = MappersEventos.TODTOs(eventos).ToList();
            return dto;
        }

        public IEnumerable<EventosDTO> GetEventosPasados()
        {
            List<Evento> eventos = RepositorioEvento.FindEventoPasado().ToList();
            if (eventos == null)
            {
                throw new ExcepcionesEvento("No se ha encontrado ningún evento");
            }
            List<EventosDTO> dto = MappersEventos.TODTOs(eventos).ToList();
            return dto;
        }
    }
}
