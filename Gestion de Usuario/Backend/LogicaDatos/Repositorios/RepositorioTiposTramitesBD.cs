using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogicaDatos.Repositorios
{
    public class RepositorioTiposTramitesDB : IRepositorioTipoTramite
    {
        public GestionUsuariosContext Contexto { get; set; }

        public RepositorioTiposTramitesDB(GestionUsuariosContext contexto)
        {
            Contexto = contexto;
        }

        public TipoTramite FindById(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionesEvento("El id brindado de trámite debe ser un entero positivo");
            }
            return Contexto.TiposTramites
                .Where(tip => tip.Id == id)
                .FirstOrDefault();
        }
    }
}
