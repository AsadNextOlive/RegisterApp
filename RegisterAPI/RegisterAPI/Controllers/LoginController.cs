using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RegisterAPI.Data;
using RegisterAPI.Model;
using static RegisterAPI.Controllers.RegisterController;

namespace RegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        //LOGIN:api/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    login.isLoggedIn = false;
                    //Custome Error Message
                    var errorResponse = new CustomerErrorResponse
                    {
                        Status = 400,
                        Error = "",
                        Data = new
                        {
                            login.isLoggedIn
                        }
                    };

                    var loggedin = await _context.Register.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);

                    if (loggedin == null)
                    {
                        login.isLoggedIn = false;
                        errorResponse.Error = "Username or password is invalid";
                        return BadRequest(errorResponse);
                    }

                    login.isLoggedIn = true;
                    //Success message
                    var response = new
                    {
                        Status = 200,
                        Message = "Login Successful",
                        Data = new
                        {
                            login.Email,
                            login.isLoggedIn
                        }
                    };
                    return Created("", response);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
