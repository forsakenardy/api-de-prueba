using api_de_prueba.Models;
using Microsoft.AspNetCore.Mvc;
using api_de_prueba.Services;

namespace api_de_prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        // GET api/products
        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        // GET api/products/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            return product is not null ? Ok(product) : NotFound();
        }

        // POST api/products
        [HttpPost]
        public IActionResult Add(Product product)
        {
            var newProduct = _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        // PUT api/products/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var result = _service.Update(id, updatedProduct);
            return result ? NoContent() : NotFound();
        }

        // DELETE api/products/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return result ? NoContent() : NotFound();
        }
    }
}
