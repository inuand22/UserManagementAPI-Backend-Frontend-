using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cedula de Identidad")]
        public string Ci { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Telefono de Usuario")]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Email de Usuario")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña de Usuario")]
        public string Pass { get; set; }

        [Required]
        [Display(Name = "Id Rol de Usuario")]
        public int IdRol { get; set; }

        [Required]
        [Display(Name = "Nombre Rol de Usuario")]
        public string NombreRol { get; set; }
    }
}
