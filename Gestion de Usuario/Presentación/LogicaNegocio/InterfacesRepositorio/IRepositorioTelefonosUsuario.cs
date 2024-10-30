﻿using LogicaNegocio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioTelefonosUsuario : IRepositorio<TelefonosUsuario>
    {
        TelefonosUsuario FindByNumber(int number);
    }
}
