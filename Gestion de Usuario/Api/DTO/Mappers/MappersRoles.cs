using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class MappersRoles
    {
        public static RolesDTO ToDTO(Rol rol)
        {
            RolesDTO dto = new RolesDTO();
            dto.Id = rol.Id;
            dto.Nombre = rol.Nombre.Valor;
            return dto;
        }

        public static List<RolesDTO> TODTOs(List<Rol> roles)
        {
            List<RolesDTO> dto = new List<RolesDTO>();
            foreach (Rol item in roles)
            {
                dto.Add(ToDTO(item));
            }
            return dto;
        }
    }
}
