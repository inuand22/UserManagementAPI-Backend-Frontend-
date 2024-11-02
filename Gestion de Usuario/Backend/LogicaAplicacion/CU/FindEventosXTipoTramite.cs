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
    public class FindEventosXTipoTramite : IFindEveXTipoTramite
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public FindEventosXTipoTramite(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public IEnumerable<EventosDTO> GetEventos(int IdTipoTramite)
        {
            // Validación de que el Id no sea cero o negativo
            if (IdTipoTramite <= 0)
            {
                throw new ExcepcionesEvento("El IdTipoTramite debe ser un valor positivo.");
            }

            // Validación de existencia: Verificar si el tipo de trámite existe en la base de datos
            var tipoTramiteExistente = RepositorioEvento.FindXTipoTramite(IdTipoTramite);
            if (tipoTramiteExistente == null)
            {
                throw new ExcepcionesEvento("El tipo de trámite especificado no existe.");
            }

            IEnumerable<EventosDTO> dto = MappersEventos.TODTOs(
                RepositorioEvento.FindXTipoTramite(IdTipoTramite).ToList()
            );

            return dto;
        }

    }
}
