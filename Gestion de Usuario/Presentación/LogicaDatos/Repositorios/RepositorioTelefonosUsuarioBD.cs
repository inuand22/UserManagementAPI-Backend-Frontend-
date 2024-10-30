using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioTelefonosUsuarioBD : IRepositorioTelefonosUsuario
    {
        public GestionUsuariosContext GestionUsuariosContext { get; set; }

        public RepositorioTelefonosUsuarioBD(GestionUsuariosContext gestionUsuariosContext)
        {
            GestionUsuariosContext = gestionUsuariosContext;
        }

        public void Add(TelefonosUsuario obj)
        {
            if (obj == null)
            {

            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TelefonosUsuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public TelefonosUsuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TelefonosUsuario obj)
        {
            throw new NotImplementedException();
        }

        public TelefonosUsuario FindByNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
}
