using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]                        // attribute
    [Route("api/[controller]")]            // attribute
    public class ProductsController : ControllerBase    // ControllerBase is a MVC class type 
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context) //injection of Store Context to make available for use,
        {
            _context = context;
        }

        [HttpGet]       // attribute: Http GET request 
        public async Task<ActionResult<List<Product>>> GetProducts()     // method: retrieve all products, asynchronous request
        {
            var products = await _context.Products.ToListAsync();       // async will not block threads while DB is getting queried
            return Ok(products);
        }

        [HttpGet("{id}")]               // method: retrieve a single product by ID, id parameter is used to distinguish between to [HttpGet] methods
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }


    }
}