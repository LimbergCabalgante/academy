using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Interfaces;
using TiendaWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<Product>
        [HttpGet]
        public ActionResult<IEnumerable<ProductForList>> Get([FromQuery]ProductFilter priceFilter,[FromServices] IProductLogic productLogic)
        {
            var products = productLogic.ListProducts().Where(t => t.Price > priceFilter.Price).Select(c => new ProductForList(c.Id, c.Name, c.Description, c.Price));
            return Ok(products);
        }

        // GET api/<Product>/5
        [HttpGet("{id}")]
        public ActionResult<ProductForList> Get(int id, [FromServices] IProductLogic productLogic)
        {
            var product = productLogic.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(new ProductForList(product.Id, product.Name, product.Description, product.Price));


        }

        // POST api/<Product>
        [HttpPost]
        public ActionResult<int> Post([FromBody] ProductBase product, [FromServices] IProductLogic productLogic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newProduct = productLogic.CreateProduct(new Dtos.Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.Value
            });
            return (Ok(newProduct.Id));
        }

        // PUT api/<Product>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductBase product, [FromServices] IProductLogic productLogic)
        {
            productLogic.UpdateProduct(new Dtos.Product
            {
                Id = id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price.Value
            });
            return Ok();
        }

        // DELETE api/<Product>/5
        [HttpDelete("{id}")]
        public ActionResult  Delete(int id, [FromServices] IProductLogic productLogic)
        {
            var borrado = productLogic.DeleteProduct(id);
            if (!borrado)
                return NotFound();
            return Ok();
        }
    }
}
