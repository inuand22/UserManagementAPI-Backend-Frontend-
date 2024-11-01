﻿using Excepciones;
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
                Evento eve = new Evento(dto.Descripcion, dto.IdUsuario, dto.FechaRegistro, dto.FechaEvento, dto.EnumTipoTramite);
                eve.id = dto.Id;
                return eve;
            }
            throw new ExcepcionesTelefonosUsuario("El Usuario no puede ser vacío");
        }

        public static EventosDTO ToDTO(Evento evento)
        {
            EventosDTO dto = new EventosDTO();
            dto.Id = evento.id;
            dto.Descripcion = evento.Descripcion;
            dto.IdUsuario = evento.User.Id;
            dto.FechaEvento = evento.FechaEvento;
            dto.FechaRegistro = evento.FechaRegistro;
            dto.EnumTipoTramite = evento.EnumTipoTramite;
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
