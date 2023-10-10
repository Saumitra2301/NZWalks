using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZxWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(NZWalks.API.Models.DTO.LoginRequest loginRequest)
        {
            //Validate loginRequest via FluentValidation APIs
            var  user=await userRepository.AuthenticateAsync(loginRequest.Username, loginRequest.Password);
            if (user!=null)
            {
               return Ok(await tokenHandler.createTokenAsync(user));
            }
            return BadRequest("UserName or Password is incorrect.");
        }
    }
}
