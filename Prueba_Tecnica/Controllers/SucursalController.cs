using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Models;
using Prueba_Tecnica.Services;

namespace Prueba_Tecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController: Controller
    {
        ISucursalService sucursalService;

        public SucursalController(ISucursalService service)
        {
            sucursalService = service;
        }

        [HttpGet]
        public IActionResult GetBranchOffice()
        {
            return Ok(sucursalService.GetBranchOffice());
        }

        [HttpPost]
        public ActionResult AddNewBranchOffice([FromBody] Sucursal sucursal)
        {
            sucursalService.AddNewBranchOffice(sucursal);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBranchOffice(string codigo, [FromBody] Sucursal sucursal)
        {
            sucursalService.UpdateBranchOffice(codigo, sucursal);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBranchOffice(string codigo)
        {
            sucursalService.DeleteBranchOffice(codigo);
            return Ok();
        }
    }
}
