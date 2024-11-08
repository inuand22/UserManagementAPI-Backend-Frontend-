﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface IFindEveXFecha
    {
        IEnumerable<EventosDTO> GetEventos(DateTime fecha1);
        IEnumerable<EventosDTO> GetEventosFuturos();
        IEnumerable<EventosDTO> GetEventosPasados();
    }
}
