using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioRolesBD : IRepositorioRol
    {
        public GestionUsuariosContext Contexto { get; set; }

        public RepositorioRolesBD(GestionUsuariosContext contexto)
        {
            Contexto = contexto;
        }

        public IEnumerable<Rol> FindAll()
        {
            return Contexto.Roles.ToList();
        }

        public Rol FindById(int Id)
        {
            return Contexto.Roles.Find(Id);
        }
    }
}
