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
    public class BorrarEvento : IDeleteEvento
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public BorrarEvento(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public void DeleteEvento(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionesEvento("El id debe ser un entero positivo");
            }
            RepositorioEvento.Delete(id);
        }
    }
}
