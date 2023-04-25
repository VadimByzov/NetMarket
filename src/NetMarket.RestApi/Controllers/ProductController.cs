using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMarket.Core.Interfaces.Services;
using NetMarket.Core.Models;

namespace NetMarket.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productService.Get();
                return Ok(products);
            }
            catch
            {
                return BadRequest(new { Error = "Custom error"});
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productService.Get(id);
                return Ok(product);
            }
            catch
            {
                return BadRequest(new { Error = "Custom error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                product = await _productService.Create(product);
                // Redirect url?
                return Created(string.Empty, product);
            }
            catch
            {
                return BadRequest(new { Error = "Custom error" });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            try
            {
                await _productService.Update(id, product);
                return NoContent();
            }
            catch
            {
                return BadRequest(new { Error = "Custom error" });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest(new { Error = "Custom error" });
            }
        }
    }
}
