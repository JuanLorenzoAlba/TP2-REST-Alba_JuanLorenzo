using Application.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOpenApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;

        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet]
        public IActionResult GetComandaByFecha(string fecha)
        {
            var result = _comandaService.GetComandaByFecha(fecha);
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateComanda(ComandaRequest request)
        {
            var result = _comandaService.CreateComanda(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        public IActionResult GetComandaById(Guid id)
        {
            var result = _comandaService.GetComandaById(id);
            return new JsonResult(result);
        }
    }
}
