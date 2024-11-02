using DTO;
using DTO.Mappers;
using Excepciones;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class FindEventosXUser : IFindEveXUser
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventosXUser(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos(int id)
        {
            if (id > 0)
            {
                IEnumerable<EventosDTO> dto = MappersEventos.TODTOs(RepositorioEvento.FindXUserId(id).ToList());
                return dto;
            }
            throw new ExcepcionesEvento("El Id debe ser un entero positivo");
        }
    }
}
