using DTO;
using Excepciones;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public IAltaEvento CUAltaEvento { get; set; }
        public IDeleteEvento CUDeleteEvento { get; set; }
        public IFindEveXId CUEventoXId { get; set; }
        public IFindEveXDescripcion CUFindEventoXDescripcion { get; set; }
        public IFindEveXFecha CUFindEventoXFecha { get; set; }
        public IFindEveXTipoTramite CUFindEventoXTipoTramite { get; set; }
        public IListadoEve CUListadoEventos { get; set; }
        public IFindEveXUser CUFindEventoXUser { get; set; }
        public IUpdateEven CUUpdateEvento { get; set; }

        public EventosController(IAltaEvento cuAltaEvento, IDeleteEvento cUDeleteEvento,
            IFindEveXId cUEventoXId, IFindEveXDescripcion cUFindEventoXDescripcion, IFindEveXFecha cUFindEventoXFecha, IFindEveXTipoTramite cUFindEventoXTipoTramite, IListadoEve cUListadoEventos, IFindEveXUser cUFindEventoXUser, IUpdateEven cuUpdateEvento)
        {
            CUAltaEvento = cuAltaEvento;
            CUDeleteEvento = cUDeleteEvento;
            CUEventoXId = cUEventoXId;
            CUFindEventoXDescripcion = cUFindEventoXDescripcion;
            CUFindEventoXFecha = cUFindEventoXFecha;
            CUFindEventoXTipoTramite = cUFindEventoXTipoTramite;
            CUListadoEventos = cUListadoEventos;
            CUFindEventoXUser = cUFindEventoXUser;
            CUUpdateEvento = cuUpdateEvento;
        }

        // GET: api/<EventosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<EventosDTO> dto = CUListadoEventos.GetEventos();
            return Ok(dto);
        }

        // GET api/Eventos/id/5
        [HttpGet("id/{id}", Name = "FindXId")]
        public IActionResult Get(int id)
        {
            // Verificación de que el ID es válido
            if (id <= 0)
            {
                return BadRequest("El id debe ser un entero positivo.");
            }

            try
            {
                var evento = CUEventoXId.GetEventos(id);

                // Verificación de que el evento existe
                if (evento == null)
                {
                    return NotFound("El evento con el ID especificado no existe.");
                }

                return Ok(evento);
            }
            catch (ExcepcionesEvento ex)
            {
                // Error específico relacionado con los eventos
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Error general
                return StatusCode(500, "Ocurrió un error en el servidor: " + ex.Message);
            }
        }

        // GET api/Eventos/descripcion/Evento(descripcion)
        [HttpGet("descripcion/{descripcion}")]
        public IActionResult Get(string descripcion)
        {
            descripcion = descripcion.Trim();
            if (descripcion == null || string.IsNullOrEmpty(descripcion) || string.IsNullOrWhiteSpace(descripcion))
            {
                return BadRequest("La descripción no puede ser vacía");
            }
            try
            {
                return Ok(CUFindEventoXDescripcion.GetEventos(descripcion));
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/Eventos/fecha/12-05-2004
        [HttpGet("fecha/{fecha}")]
        public IActionResult Get(DateTime fecha)
        {

            if (fecha.Year > DateTime.Now.Year + 2)
            {
                return BadRequest("Los años no pueden ser mayores a 2");
            }

            try
            {
                var eventos = CUFindEventoXFecha.GetEventos(fecha);
                if (eventos == null || !eventos.Any())
                {
                    return NotFound("No se encontraron eventos para la fecha especificada.");
                }

                return Ok(eventos);
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        // GET api/Eventos/enumTramite
        [HttpGet("/IdTipoTramite/{idTipoTramite}")]
        public IActionResult GetEveXIdTramite(int idTipoTramite)
        {
            try
            {
                var eventos = CUFindEventoXTipoTramite.GetEventos(idTipoTramite);
                if (eventos == null || !eventos.Any())
                {
                    return NotFound("No se encontraron eventos para el tipo de trámite especificado.");
                }

                return Ok(eventos);
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        // GET api/Eventos/idUser/3
        [HttpGet("idUser/{idUser}")]
        public IActionResult GetxIdUser(int idUser)
        {
            if (idUser <= 0)
            {
                return BadRequest("El id debe ser un entero positivo.");
            }

            try
            {
                var eventos = CUFindEventoXUser.GetEventos(idUser);
                if (eventos == null || !eventos.Any())
                {
                    return NotFound("No se encontraron eventos para el usuario especificado.");
                }

                return Ok(eventos);
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        // GET api/Eventos/futuros/12-05-2004
        [HttpGet("futuros")]
        public IActionResult GetEventosFuturos()
        {
            try
            {
                var eventos = CUFindEventoXFecha.GetEventosFuturos();
                if (eventos == null || !eventos.Any())
                {
                    return NotFound("No se encontraron eventos para la fecha especificada.");
                }

                return Ok(eventos);
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        // GET api/Eventos/pasados/12-05-2004
        [HttpGet("pasados")]
        public IActionResult GetEventosPasados()
        {
            try
            {
                var eventos = CUFindEventoXFecha.GetEventosPasados();
                if (eventos == null || !eventos.Any())
                {
                    return NotFound("No se encontraron eventos para la fecha especificada.");
                }

                return Ok(eventos);
            }
            catch (ExcepcionesEvento ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error interno en el servidor.");
            }
        }

        // POST api/Eventos
        [HttpPost]
        public IActionResult CreateEvento([FromBody] EventosDTO dto)
        {

            if (dto == null)
            {
                return BadRequest("El evento no puede ser vacío.");
            }

            if (dto.Id != 0)
            {
                return BadRequest("No debe brindar id");
            }

            if (string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                return BadRequest("La descripción del evento es requerido.");
            }

            try
            {
                CUAltaEvento.AddEvento(dto);
                return CreatedAtAction(nameof(GetxIdUser), new { idUser = dto.Id }, dto);
            }

            catch (ExcepcionesEvento ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExcepcionesUsuarios ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException);
            }
        }

        // PUT api/Eventos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EventosDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("El objeto dto no puede ser nulo.");
                }

                if (id != dto.Id)
                {
                    return BadRequest("El ID del URL no coincide con el ID del dto.");
                }

                var eventoExistente = CUEventoXId.GetEventos(id);
                if (eventoExistente == null)
                {
                    return NotFound("El evento no existe.");
                }

                CUUpdateEvento.UpdateEve(dto);

                return Ok("El evento se ha actualizado correctamente.");
            }
            catch (ExcepcionesEvento ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/Eventos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var eventoExistente = CUEventoXId.GetEventos(id);

                if (eventoExistente == null)
                {
                    return NotFound("El evento no existe.");
                }

                CUDeleteEvento.DeleteEvento(id);

                return NoContent();
            }

            catch (ExcepcionesEvento ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
