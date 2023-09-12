using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Data;
using Prueba_Tecnica.Models;
using Prueba_Tecnica.Services;

namespace Prueba_Tecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TecnicoController : Controller
    {
        ITecnicoService tecnicoService;

        public TecnicoController (ITecnicoService service)
        {
            tecnicoService = service;
        }

        [HttpGet]
        public IActionResult GetTechnicians()
        {
            return Ok(tecnicoService.GetAllTechnicians());
        }

        [HttpGet("{codigo}")]
        public IActionResult GetTechnician(string codigo)
        {
            return Ok(tecnicoService.GetTechnician(codigo));
        }

        [HttpPost]
        public ActionResult AddNewTechnician([FromBody] DataTecnicoRequest request)
        {
            tecnicoService.AddNewTechnician(request.tecnico, request.elementos);
            return Ok();
        }

        [HttpPut]
        public ActionResult EditTechnician(string codigo, [FromBody] DataTecnicoRequest request)
        {
            tecnicoService.UpdateTechnician(codigo, request.tecnico, request.elementos);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTechnician(string codigo)
        {
            tecnicoService.DeleteTechnician(codigo);
            return Ok();
        }
    }
}
