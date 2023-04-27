using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOpenApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _service;

        public ComandaController(IComandaService comandaService)
        {
            _service = comandaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ComandaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetComandaByFecha(string? fecha)
        {
            try
            {
                var result = _service.GetComandaByFecha(fecha);
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest
                {
                    Message = $"El formato de la fecha ingresada es incorrecto '{fecha}'. El formato es DD/MM/AAAA"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ComandaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateComanda(ComandaRequest request)
        {
            try
            {
                var result = _service.CreateComanda(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ComandaGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetComandaById(Guid id)
        {
            try
            {
                var result = _service.GetComandaById(id);

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }
    }
}
