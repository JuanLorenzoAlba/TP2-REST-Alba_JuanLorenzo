using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOpenApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _service;

        public MercaderiaController(IMercaderiaService mercaderiaService)
        {
            _service = mercaderiaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MercaderiaGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetMercaderiaListFilters(int tipo, string? nombre, string? orden = "ASC")
        {
            var result = _service.GetMercaderiaListFilters(tipo, nombre, orden);
            return new JsonResult(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MercaderiaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreateMercaderia(MercaderiaRequest request)
        {
            if (_service.ExisteMercaderiaNombre(request.Nombre))
            {
                return Conflict(new BadRequest
                {
                    Message = $"Ya existe una mercadería con el nombre '{request.Nombre}'."
                });
            }
            try
            {
                var result = _service.CreateMercaderia(request);
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
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetMercaderiaById(int id)
        {
            try
            {
                var result = _service.GetMercaderiaById(id);
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult UpdateMercaderia(int id, MercaderiaRequest request)
        {
            if (_service.ExisteMercaderiaNombre(request.Nombre) && _service.GetMercaderiaById(id).Nombre != request.Nombre)
            {
                return Conflict(new BadRequest
                {
                    Message = $"Ya existe una mercadería con el nombre '{request.Nombre}'."
                });
            }
            try
            {
                var result = _service.UpdateMercaderia(id, request);
                return new JsonResult(result);
            }

            catch (ArgumentException ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }

            catch (Exception ex)
            {
                return BadRequest(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MercaderiaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult RemoveMercaderia(int id)
        {
            if (_service.ExisteMercaderiaEnComanda(id))
            {
                return Conflict(new BadRequest
                {
                    Message = $"La mercaderia con id '{id}' que intenta borrar se encuentra en una encomienda"
                });
            }
            try
            {
                var result = _service.RemoveMercaderia(id);
                return new JsonResult(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new BadRequest
                {
                    Message = ex.Message
                });
            }
        }
    }
}
