using Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ActionResult<IEnumerable<ProductForList>> Get([FromServices] IProductLogic productLogic)
        {
            var products = productLogic.ListProducts().Select(c => new ProductForList(c.Id, c.Name, c.Description, c.Price, c.CategoryId, c.Status, c.ImageUrl));
            return Ok(products);
        }

        // GET api/<Product>/id
        [HttpGet("{id}")]
        public ActionResult<ProductForList> Get(int id, [FromServices] IProductLogic productLogic)
        {
            var product = productLogic.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(new ProductForList(product.Id, product.Name, product.Description, product.Price, product.CategoryId, product.Status, product.ImageUrl));
        }

        // GET api/<Product>/pagination
        [HttpGet("pagination")]
        public ActionResult<ProductForList> Get([Required]int pageIndex, [Required]int pageSize, string orderBy, int orderDirection, string search, int category, [FromServices] IProductLogic productLogic)
        {
            var products = productLogic.GetProductsPaginated(pageIndex, pageSize, orderBy, orderDirection, search, category);
            return Ok(products);
        }

        // POST api/<Product>
        [HttpPost]
        public ActionResult Post([FromBody] ProductBase product, [FromServices] IProductLogic productLogic)
        {
            productLogic.CreateProduct(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price.Value,
                CategoryId = product.CategoryId,
                Status = product.Status,
                ImageUrl = product.ImageUrl,
            });
            return Ok();
        }

        // PUT api/<Product>/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductBase product, [FromServices] IProductLogic productLogic)
        {
            productLogic.UpdateProduct(new Product
            {
                Id = id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price.Value,
                CategoryId = product.CategoryId,
                Status = product.Status,
                ImageUrl = product.ImageUrl

            });
            return Ok();
        }

        // DELETE api/<Product>/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromServices] IProductLogic productLogic)
        {
            var borrado = productLogic.DeleteProduct(id);
            if (!borrado)
                return NotFound();
            return Ok();
        }

        //Other Product-related requets

        // GET api/<Product>/categories
        [HttpGet("categories")]
        public ActionResult<Category> GetCategories([FromServices] IProductLogic productLogic)
        {
            var categories = productLogic.GetCategories();
            return Ok(categories);
        }

        // GET api/<Product>/products-by-category
        [HttpGet("products-by-category")]
        public ActionResult<ProductForList> GetProductsByCategory(int category, string search, [FromServices] IProductLogic productLogic)
        {
            var products = productLogic.GetProductsByCategory(category, search);
            return Ok(products);
        }
    }
}
