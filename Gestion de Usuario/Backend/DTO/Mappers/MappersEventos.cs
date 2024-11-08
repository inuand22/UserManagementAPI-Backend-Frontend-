using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class MappersEventos
    {
        public static Evento FromDTO(EventosDTO dto)
        {
            if (dto != null)
            {
                DescripcionEvento descripcion = new DescripcionEvento(dto.Descripcion);
                Evento eve = new Evento(descripcion, dto.IdUsuario, dto.FechaRegistro, dto.FechaEvento, dto.IdTramite);
                eve.Id = dto.Id;
                eve.IdTipoTramite = dto.IdTramite;
                eve.IdUser = dto.IdUsuario;
                return eve;
            }
            throw new ExcepcionesTelefonosUsuario("El Usuario no puede ser vacío");
        }

        public static EventosDTO ToDTO(Evento evento)
        {
            EventosDTO dto = new EventosDTO();
            dto.Id = evento.Id;
            dto.Descripcion = evento.Descripcion.Valor;
            dto.IdUsuario = evento.User.Id;
            dto.FechaEvento = evento.FechaEvento;
            dto.FechaRegistro = evento.FechaRegistro;
            dto.IdTramite = evento.TipoTramite.Id;
            dto.IdUsuario = evento.User.Id;
            return dto;
        }

        public static List<EventosDTO> TODTOs(List<Evento> users)
        {
            List<EventosDTO> dto = new List<EventosDTO>();
            foreach (Evento item in users)
            {
                dto.Add(ToDTO(item));
            }
            return dto;
        }
    }
}
