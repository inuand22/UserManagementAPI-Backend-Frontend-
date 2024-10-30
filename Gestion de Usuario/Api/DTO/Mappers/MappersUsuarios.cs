using Excepciones;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Mappers
{
    public class MappersUsuarios
    {
        public static Usuario FromDTO(UsuarioDTO dto)
        {
            if (dto != null)
            {
                CiUsuario ci = new CiUsuario(dto.Ci);
                NombreUsuario nombre = new NombreUsuario(dto.Nombre);
                ApellidoUsuario apellido = new ApellidoUsuario(dto.Apellido);
                EmailUsuario email = new EmailUsuario(dto.Email);
                PasswordUsuario pass = new PasswordUsuario(dto.Pass);
                TelefonoUsuario telefono = new TelefonoUsuario(dto.Telefono);
                Usuario user = new Usuario(ci, nombre, apellido,
                    telefono, email, null, pass);
                user.Id = dto.Id;
                return user;
            }
            throw new ExcepcionesTelefonosUsuario("El Usuario no puede ser vacío");
        }

        public static UsuarioDTO ToDTO(Usuario user)
        {
            UsuarioDTO dto = new UsuarioDTO();
            dto.Id = user.Id;
            dto.Ci = user.Ci.Valor;
            dto.Nombre = user.Nombre.Valor;
            dto.Apellido = user.Apellido.Valor;
            dto.Telefono = user.Telefono.Valor;
            dto.Email = user.Email.Valor;
            dto.Pass = user.Pass.Valor;
            dto.IdRol = user.IdRol;
            dto.NombreRol = user.Rol.Nombre.Valor;
            return dto;
        }

        public static List<UsuarioDTO> TODTOs(List<Usuario> users)
        {
            List<UsuarioDTO> dto = new List<UsuarioDTO>();
            foreach (Usuario item in users)
            {
                dto.Add(ToDTO(item));
            }
            return dto;
        }
    }
}
