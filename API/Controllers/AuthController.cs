//using API.DTO.Auth;
//using API.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;
//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }
//        // GET: api/<AuthController>
//        [HttpPost("Login")]
//        public String Login(Login_DTO login_DTO)
//        {
//            var token = _authService.Login(login_DTO);
//            return token;
//        }

//    }
//}
