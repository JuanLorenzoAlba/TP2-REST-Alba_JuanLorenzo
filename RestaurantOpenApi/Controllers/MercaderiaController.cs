using Application.Interfaces;
using Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantOpenApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _mercaderiaService;

        public MercaderiaController(IMercaderiaService mercaderiaService)
        {
            _mercaderiaService = mercaderiaService;
        }

        [HttpGet]
        public IActionResult GetMercaderiaListFilters(int tipo, string? nombre, string? orden = "ASC")
        {
            var result = _mercaderiaService.GetMercaderiaListFilters(tipo, nombre, orden);
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateMercaderia(MercaderiaRequest request)
        {
            var result = _mercaderiaService.CreateMercaderia(request);
            return new JsonResult(result) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        public IActionResult GetMercaderiaById(int id)
        {
            var result = _mercaderiaService.GetMercaderiaById(id);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMercaderia(int id, MercaderiaRequest request)
        {
            var result = _mercaderiaService.UpdateMercaderia(id, request);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveMercaderia(int id)
        {
            var result = _mercaderiaService.RemoveMercaderia(id);
            return new JsonResult(result);
        }
    }
}
