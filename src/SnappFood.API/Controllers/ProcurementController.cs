using Microsoft.AspNetCore.Mvc;
using SnappFood.Model;
using SnappFood.Service;

namespace SnappFood.API.Controllers
{
    [ApiController]
    [Route("api/procurement")]   
    public class ProcurementController : ControllerBase
    {
        private IProcurementService _procurementService;

        public ProcurementController(IProcurementService procurementService)
        {
            _procurementService = procurementService;
        }
        // POST api/procurement/buy
        [HttpPost]
        public async Task<IActionResult> Buy([FromBody] ProductToBuyDto productToBuyDto)
        {
            var result = await _procurementService.Buy(productToBuyDto);
            if (result.Succeeded)
                return NoContent();


            return BadRequest(result.Error?.Message);
        }

        
    }
}
