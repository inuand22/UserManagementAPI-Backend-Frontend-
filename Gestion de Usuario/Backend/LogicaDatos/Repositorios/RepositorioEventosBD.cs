using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioEventosBD : IRepositorioEvento
    {
        public GestionUsuariosContext Contexto { get; set; }

        public RepositorioEventosBD(GestionUsuariosContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Evento obj)
        {
            obj.Validate();
            if (obj == null)

            {
                throw new ExcepcionesEvento("Evento no puede ser vacío");
            }

            if (FindXFecha(obj.FechaEvento).Contains(obj))
            {
                throw new ExcepcionesEvento("No se puede crear un evento con la misma fecha/hora");
            }

            Contexto.Eventos.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            Evento obj = Contexto.Eventos.Find(id);
            if (obj == null)
            {
                throw new ExcepcionesEvento("Este Evento no existe");
            }
            bool existe = Contexto.Usuarios
                .Where(usu => usu.Eventos.Any(eve => eve.Id == id))
                .Count() > 0;
            if (existe)
            {
                throw new ExcepcionesEvento("Este evento está siendo utilizado por un Usuario");
            }
            Contexto.Eventos.Remove(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Evento> FindAll()
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
                .ToList();
        }

        public Evento FindById(int id)
        {
            if (id <= 0)
            {
                throw new ExcepcionesEvento("El id debe ser un entero positivo");
            }
            if (id == null)
            {
                throw new ExcepcionesEvento("El id no puede ser cero");
            }
            return Contexto.Eventos.Where(eve => eve.Id == id)
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
                .FirstOrDefault();
        }

        public void Update(Evento obj)
        {
            Evento buscado = FindById(obj.Id);
            if (buscado != null)
            {
                Contexto.Entry(buscado).State = EntityState.Detached;
                Contexto.Update(obj);
                Contexto.SaveChanges();
            }
            else
            {
                throw new ExcepcionesEvento("No existe el evento.");
            }
        }

        public IEnumerable<Evento> FindXDescripcion(string name)
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
               .Where(eve => eve.Descripcion.Valor.Contains(name))
               .ToList();
        }

        public IEnumerable<Evento> FindXFecha(DateTime fecha1)
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
                .Where(eve => eve.FechaEvento.Date == fecha1.Date)
                .ToList();
        }

        public IEnumerable<Evento> FindXUserId(int id)
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
               .Where(eve => eve.User.Id == id)
               .ToList();
        }

        public IEnumerable<Evento> FindXTipoTramite(int IdTipoTramite)
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
               .Where(eve => eve.TipoTramite.Id == IdTipoTramite)
               .ToList();
        }

        public IEnumerable<Evento> FindEventoFuturo()
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
                .Where(eve => eve.FechaEvento >= DateTime.Now)
                .OrderBy(eve => eve.FechaEvento)
                .ToList();
        }

        public IEnumerable<Evento> FindEventoPasado()
        {
            return Contexto.Eventos
                .Include(eve => eve.User)
                .Include(eve => eve.TipoTramite)
            .Where(eve => eve.FechaEvento < DateTime.Now)
            .OrderBy(eve => eve.FechaEvento)
            .ToList();
        }
    }
}

