using LogicaNegocio.EntidadesDominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioEvento : IRepositorio<Evento>
    {
        IEnumerable<Evento> FindXDescripcion(string name);
        IEnumerable<Evento> FindXFecha(DateTime fecha);
        IEnumerable<Evento> FindXUserId(int id);
        IEnumerable<Evento> FindXTipoTramite(int idTipoTramite);
    }
}
