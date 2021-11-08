using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Dtos.Carts;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Services.Carts;
using Microsoft.AspNetCore.Authorization;

namespace Supermarket.Application.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart([FromBody] CartDtoCreate cart)
        {
            return Ok(await _service.Post(cart));
        }
    }
}
