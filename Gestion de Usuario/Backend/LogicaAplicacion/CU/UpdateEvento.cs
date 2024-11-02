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
    public class UpdateEvento : IUpdateEven
    {
        public IRepositorioEvento RepositorioEvento { get; set; }
        public IRepositorioUsuario RepositorioUsuario { get; set; }
        public IRepositorioTipoTramite RepositorioTipoTramite { get; set; }

        public UpdateEvento(IRepositorioEvento repositorioEvento, IRepositorioUsuario repositorioUsuario
            , IRepositorioTipoTramite repositorioTipoTramite)
        {
            RepositorioEvento = repositorioEvento;
            RepositorioUsuario = repositorioUsuario;
            RepositorioTipoTramite = repositorioTipoTramite;
        }

        public void UpdateEve(EventosDTO dto)
        {
            if (dto == null)
            {
                throw new ExcepcionesEvento("Debe de brindar un evento para modificar");
            }
            Usuario user = RepositorioUsuario.FindById(dto.IdUsuario);
            TipoTramite tipoTramite = RepositorioTipoTramite.FindById(dto.IdTramite);
            if (user == null)
            {
                throw new ExcepcionesEvento("No se encontró Usuario");
            }
            if (tipoTramite == null)
            {
                throw new ExcepcionesEvento("No se encontró tipo trámite");
            }
            else
            {
                RepositorioEvento.Update(MappersEventos.FromDTO(dto));
            }
        }
    }
}
