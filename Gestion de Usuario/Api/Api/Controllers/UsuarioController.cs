using DTO;
using DTO.Mappers;
using Excepciones;
using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IListadoUsuarios CUListadoUsuarios { get; set; }
        public IFindUsuarioXId CUFindUserXId { get; set; }
        public IDeleteUsuario CUDeleteUser { get; set; }
        public IAltaUsuario CUAltaUsuario { get; set; }
        public IUpdateUsuario CUUpdateUsuario { get; set; }

        public UsuarioController(IListadoUsuarios cuListadoUsuarios, IFindUsuarioXId cUFindUserXId,
            IDeleteUsuario cuDeleteUser, IAltaUsuario cUAltaUsuario, IUpdateUsuario cUUpdateUsuario)
        {
            CUListadoUsuarios = cuListadoUsuarios;
            CUFindUserXId = cUFindUserXId;
            CUDeleteUser = cuDeleteUser;
            CUAltaUsuario = cUAltaUsuario;
            CUUpdateUsuario = cUUpdateUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(CUListadoUsuarios.DTOUsuarios());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}", Name = "FindById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            try
            {
                UsuarioDTO dto = CUFindUserXId.DTOUsuario(id);

                if (dto == null)
                {
                    return NotFound("No se encontró un usuario con el ID proporcionado.");
                }

                return Ok(dto);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] UsuarioDTO? dto)
        {
            if (dto.Id != 0)
            {
                return BadRequest("No debe proporcionar un Id");
            }
            if (dto == null)
            {
                return BadRequest("Debe proporcionar un Usuario");
            }
            try
            {
                CUAltaUsuario.AltaUser(dto);
                return CreatedAtRoute("FindById", new { id = dto.Id }, dto);
            }
            catch (ExcepcionesTelefonosUsuario ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExcepcionesRoles ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + ex.InnerException);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int? id, [FromBody] UsuarioDTO? dto)
        {
            if (dto == null)
            {
                return BadRequest("Debe proporcionar un Usuario");
            }
            if (id != dto.Id)
            {
                return BadRequest("Los Id´s no pueden ser diferentes");
            }
            try
            {
                CUUpdateUsuario.UpdateUsuario(dto);
                return Ok();
            }
            catch (ExcepcionesTelefonosUsuario ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExcepcionesRoles ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("El id no debe ser vacío");
            }
            if (id <= 0)
            {
                return BadRequest("El id debe ser un entero mayor a cero");
            }
            try
            {
                CUDeleteUser.DeleteUser(id);
                return NoContent();
            }
            catch (ExcepcionesTelefonosUsuario ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrión un error, no se pudo realizar la baja del usuario");
            }
        }
    }
}
