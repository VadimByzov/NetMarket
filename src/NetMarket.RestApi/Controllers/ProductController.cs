using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMarket.Core.Interfaces.Services;

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
    }
}
