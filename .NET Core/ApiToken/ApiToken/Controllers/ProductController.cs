using ApiToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiToken.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryClass _repository;

        public ProductController(IRepositoryClass repository)
        {
           _repository = repository;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetData()
        {
            var data = _repository.GetAllProducts();
            return Ok(new { data = data });
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct([FromBody]ProductModel pdt)
        {
            _repository.Add(pdt);
            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult EditProduct([FromBody]ProductModel product)
        {
            _repository.Edit(product);
            return Ok(new { success = true });
        }

        [HttpGet("{productId}")]
        
        public IActionResult GetOldProductName(int productId)
        {
            var product = _repository.GetOldDetail(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
