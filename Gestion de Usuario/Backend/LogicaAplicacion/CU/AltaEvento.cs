using DTO;
using DTO.Mappers;
using Excepciones;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CU
{
    public class AltaEvento : IAltaEvento
    {
        public IRepositorioEvento RepositorioEvento { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioTipoTramite RepositorioTipoTramite { get; set; }

        public AltaEvento(IRepositorioEvento repositorioEvento, IRepositorioUsuario repositorioUsuario,
            IRepositorioTipoTramite repositorioTipoTramite)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioUsuario = repositorioUsuario;
            RepositorioTipoTramite = repositorioTipoTramite;
        }

        public void AddEvento(EventosDTO dto)
        {
            if (dto == null)
            {
                throw new ExcepcionesEvento("El Evento no puede ser vacío");
            }
            TipoTramite tipoTramite = RepositorioTipoTramite.FindById(dto.IdTramite);
            Evento eve = MappersEventos.FromDTO(dto);
            Usuario user = RepositorioUsuario.FindById(eve.IdUser);
            if (user == null)
            {
                throw new ExcepcionesEvento("El usuario no existe");
            }
            if (tipoTramite == null)
            {
                throw new ExcepcionesEvento("El tipo de trámite no existe");
            }
            eve.User = user;
            eve.TipoTramite = tipoTramite;
            RepositorioEvento.Add(eve);
            dto.Id = eve.Id;
        }
    }
}
