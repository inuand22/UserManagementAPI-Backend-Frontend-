using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    [Owned]
    public class Rol
    {
        public int Id { get; set; }
        public NombreRol Nombre { get; set; }
        public List<Usuario>? Usuarios { get; set; }

        [NotMapped]
        public List<int>? IdUsuarios { get; set; }
    }
}
