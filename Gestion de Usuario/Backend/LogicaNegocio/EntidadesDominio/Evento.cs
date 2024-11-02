using Excepciones;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class Evento : IValidable
    {
        public int id { get; set; }
        public DescripcionEvento Descripcion { get; set; }

        public Usuario User { get; set; }

        [NotMapped]
        public int IdUser { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEvento { get; set; }

        public TipoTramite TipoTramite { get; set; }

        [NotMapped]
        public int IdTipoTramite { get; set; }

        protected Evento() { }

        public Evento(DescripcionEvento descripcion, Usuario user, DateTime fechaRegistro, DateTime fechaEvento, TipoTramite tipoTramite)
        {
            Descripcion = descripcion;
            User = user;
            FechaRegistro = fechaRegistro;
            FechaEvento = fechaEvento;
            TipoTramite = tipoTramite;
            Validate();
        }

        public Evento(DescripcionEvento descripcion, int idUser, DateTime fechaRegistro, DateTime fechaEvento, int idTipoTramite)
        {
            Descripcion = descripcion;
            IdUser = idUser;
            FechaRegistro = fechaRegistro;
            FechaEvento = fechaEvento;
            IdTipoTramite = idTipoTramite;
            Validate();
        }

        public void Validate()
        {
            if (FechaRegistro > FechaEvento)
            {
                throw new ExcepcionesEvento("La fecha de registro no puede ser mayor a la fecha del evento");
            }
            if (FechaEvento == null || FechaRegistro == null)
            {
                throw new ExcepcionesEvento("Las fechas no pueden ser vacías.");
            }
            if (FechaEvento.Year > DateTime.Now.Year + 2)
            {
                throw new ExcepcionesEvento("No se pueden realizar registros de eventos para más de 2 años de diferencia.");
            }
        }
    }
}
