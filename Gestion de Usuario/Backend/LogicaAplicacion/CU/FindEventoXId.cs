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
    public class FindEventoXId : IFindEveXId
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventoXId(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public EventosDTO GetEventos(int id)
        {
            if (id > 0)
            {
                Evento eve = RepositorioEvento.FindById(id);
                if (eve == null)
                {
                    throw new ExcepcionesEvento("No se encontró el evento");
                }
                EventosDTO dto = MappersEventos.ToDTO(eve);
                return dto;
            }
            throw new ExcepcionesEvento("El if debe ser un entero positivo");
        }
    }
}
