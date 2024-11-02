using DTO;
using DTO.Mappers;
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
    public class TipoTramiteXId : IFindTipoTramiteXId
    {
        public IRepositorioTipoTramite RepositorioTipoTramite { get; set; }

        public TipoTramiteXId(IRepositorioTipoTramite repositorioTipoTramite)
        {
            RepositorioTipoTramite = repositorioTipoTramite;
        }

        public TipoTramitesDTO FindXId(int Id)
        {

            if (Id <= 0)
            {
                throw new ExcepcionesEvento("Tipo Trámite no encontrado");
            }

            return MappersTipoTramite.ToDTO(RepositorioTipoTramite.FindById(Id));
        }
    }
}
