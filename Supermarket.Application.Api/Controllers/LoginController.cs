using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Services.Users;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Supermarket.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }


        // POST: api/Login
        [HttpPost]
        public async Task<Object> Login([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.FindByLogin(user);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

    }
}
