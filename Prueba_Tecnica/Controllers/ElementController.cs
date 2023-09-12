using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementController : Controller
    {
        IElementoServices sucursalService;

        public ElementController(IElementoServices service)
        {
            sucursalService = service;
        }

        [HttpGet]
        [Route("/dbconexion")]
        public IActionResult GetDB([FromServices] ProgramContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetElement()
        {
            return Ok(sucursalService.GetElement());
        }

        [HttpPost]
        public ActionResult AddNewElement([FromBody] Elemento elemento)
        {
            sucursalService.AddNewElement(elemento);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateElement(string codigo, [FromBody] Elemento elemento)
        {
            sucursalService.UpdateElement(codigo, elemento);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteElement(string codigo)
        {
            sucursalService.DeleteElement(codigo);
            return Ok();
        }
    }
}
