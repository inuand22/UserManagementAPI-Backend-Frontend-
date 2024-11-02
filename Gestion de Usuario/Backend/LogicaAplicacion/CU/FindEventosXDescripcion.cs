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
    public class FindEventosXDescripcion : IFindEveXDescripcion
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventosXDescripcion(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos(string descripcion)
        {
            descripcion = descripcion.Trim();
            if (descripcion != null || !string.IsNullOrEmpty(descripcion) || !string.IsNullOrWhiteSpace(descripcion))
            {
                List<Evento> eventos = RepositorioEvento.FindXDescripcion(descripcion).ToList();
                if (!eventos.Any() || eventos.Count() == 0)
                {
                    throw new ExcepcionesEvento("No se encontró ningún evento");
                }
                List<EventosDTO> dto = MappersEventos.TODTOs(eventos);
                return dto;
            }
            throw new ExcepcionesEvento("La descripción no puede ser vacía");
        }
    }
}
