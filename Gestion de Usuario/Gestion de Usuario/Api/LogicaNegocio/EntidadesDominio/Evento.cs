using Excepciones;
using LogicaNegocio.InterfacesDominio;
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
        public string Descripcion { get; set; }
        public Usuario User { get; set; }

        [NotMapped]
        public int IdUser { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEvento { get; set; }
        public ETipoTramite EnumTipoTramite { get; set; }

        protected Evento() { }

        public Evento(string descripcion, Usuario user, DateTime fechaRegistro, DateTime fechaEvento, ETipoTramite enumTipoTramite)
        {
            Descripcion = descripcion;
            User = user;
            FechaRegistro = fechaRegistro;
            FechaEvento = fechaEvento;
            EnumTipoTramite = enumTipoTramite;
            Validate();
        }

        public Evento(string descripcion, int idUser, DateTime fechaRegistro, DateTime fechaEvento, ETipoTramite enumTipoTramite)
        {
            Descripcion = descripcion;
            IdUser = idUser;
            FechaRegistro = fechaRegistro;
            FechaEvento = fechaEvento;
            EnumTipoTramite = enumTipoTramite;
            Validate();
        }

        public void Validate()
        {
            if ((int)EnumTipoTramite != 1 || (int)EnumTipoTramite != 2 || (int)EnumTipoTramite != 3)
            {
                throw new ExcepcionesEvento("No Existe el tipo de trámite");
            }
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
