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

        public AltaEvento(IRepositorioEvento repositorioEvento, IRepositorioUsuario repositorioUsuario)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioUsuario = repositorioUsuario;
        }

        public void AddEvento(EventosDTO dto)
        {
            if (dto == null)
            {
                throw new ExcepcionesEvento("El Evento no puede ser vacío");
            }
            Evento eve = MappersEventos.FromDTO(dto);
            if ((int)(eve.EnumTipoTramite) == 1)
            {
                eve.EnumTipoTramite = ETipoTramite.primeraVez;
            }
            if ((int)(eve.EnumTipoTramite) == 2)
            {
                eve.EnumTipoTramite = ETipoTramite.renovacion;
            }
            if ((int)(eve.EnumTipoTramite) == 3)
            {
                eve.EnumTipoTramite = ETipoTramite.otro;
            }
            Usuario user = RepositorioUsuario.FindById(eve.IdUser);
            if (user == null)
            {
                throw new ExcepcionesEvento("El usuario no existe");
            }
            eve.User = user;
            RepositorioEvento.Add(eve);
            dto.Id = eve.id;
        }
    }
}
