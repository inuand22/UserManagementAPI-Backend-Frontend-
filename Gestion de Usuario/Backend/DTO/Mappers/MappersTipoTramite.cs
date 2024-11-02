using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class MappersTipoTramite
    {
        public static TipoTramitesDTO ToDTO(TipoTramite rol)
        {
            TipoTramitesDTO dto = new TipoTramitesDTO();
            dto.Id = rol.Id;
            dto.Nombre = rol.Nombre.Valor;
            return dto;
        }

        public static List<TipoTramitesDTO> TODTOs(List<TipoTramite> tiposTramites)
        {
            List<TipoTramitesDTO> dto = new List<TipoTramitesDTO>();
            foreach (TipoTramite item in tiposTramites)
            {
                dto.Add(ToDTO(item));
            }
            return dto;
        }
    }
}
