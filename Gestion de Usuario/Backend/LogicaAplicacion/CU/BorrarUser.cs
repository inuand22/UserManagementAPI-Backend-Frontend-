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
    public class BorrarUser : IDeleteUsuario
    {
        public IRepositorioUsuario RepositorioUsuario { get; set; }

        public BorrarUser(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void DeleteUser(int id)
        {
            RepositorioUsuario.Delete(id);
        }
    }
}
