using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Dtos;
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
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }


        // POST: api/Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.FindByLogin(login));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

    }
}
