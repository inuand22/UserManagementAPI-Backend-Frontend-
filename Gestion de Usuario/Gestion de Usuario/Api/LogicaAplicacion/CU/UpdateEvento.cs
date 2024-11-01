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
    public class UpdateEvento : IUpdateEven
    {
        public IRepositorioEvento RepositorioEvento { get; set; }

        public UpdateEvento(IRepositorioEvento repositorioEvento)
        {
            RepositorioEvento = repositorioEvento;
        }

        public void UpdateEve(EventosDTO dto)
        {
            if (dto != null)
            {
                RepositorioEvento.Update(MappersEventos.FromDTO(dto));
            }
            else
            {
                throw new ExcepcionesEvento("Debe de brindar un evento para modificar");
            }
        }
    }
}
