using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.identity.Api.Dtos;

namespace Pri.identity.Api.Controllers
{
    [Authorize]
	[Route("api/[controller]")]
	[ApiController] 
	public class ProductsController : ControllerBase 
	{ 
		List<ProductDto> products = new List<ProductDto>(); 
		
		public ProductsController() 
		{ 
			GenerateSomeProducts(); 
		} 
		
		[HttpGet] 
		public async Task<IActionResult> Get() 
		{ 
			return Ok(products); 
		} 
		
		private void GenerateSomeProducts() 
		{ 
			products.Add(new ProductDto 
			{ 
				Id = Guid.NewGuid(), 
				Name = "Product 1", 
				Price = 23.45m 
			}); 
			
			products.Add(new ProductDto 
			{ 
				Id = Guid.NewGuid(), 
				Name = "Product 2", 
				Price = 43.45m 
			}); 
			
			products.Add(new ProductDto 
			{ 
				Id = Guid.NewGuid(), 
				Name = "Product 3", 
				Price = 63.45m 
			}); 
		} 
	}
}
