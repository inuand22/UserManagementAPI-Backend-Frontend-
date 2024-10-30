using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio
{
    public class TelefonosUsuario
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Usuario User { get; set; }

        [NotMapped]
        public int IdUsuario { get; set; }
    }
}
