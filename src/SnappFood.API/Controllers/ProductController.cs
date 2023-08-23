using Microsoft.AspNetCore.Mvc;
using SnappFood.Model;
using SnappFood.Service;

namespace SnappFood.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private IProductService _producctService;

        public ProductController(IProductService productService)
        {
            _producctService = productService;
        }
        // GET: products/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _producctService.GetProduct(id);

            if (!result.Succeeded)
            {
                //todo:Error Codes
                if (result.Error?.Code == 401) { return NotFound(); }
                return BadRequest(result.Error?.Message);
            }

            return Ok(result.Entity);
        }
        // POST: products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductToCreateDto productToCreateDto)
        {
            var result = await _producctService.CreateProductAsync(productToCreateDto);
            if (result.Succeeded)
                return CreatedAtAction(nameof(GetProduct), new { id = result.Entity }, result.Entity);


            return BadRequest(result.Error?.Message);

        }
        // PUT: products/{id}/increase-inventory-counts
        [HttpPut]
        [Route("{id}/increase-inventory-count")]
        public async Task<IActionResult> IncreaseInventoryCount(int id, CountToIncreaseInventoryDto increaseInventoryCountDto)
        {
            var result = await _producctService.UpdateProductInventoryCountAsync(id, increaseInventoryCountDto.count);
            if (!result.Succeeded)
            {
                if (result.Error?.Code == 401) { return NotFound(); }
                return BadRequest(result.Error?.Message);
            }

            return NoContent();

        }
    }
}