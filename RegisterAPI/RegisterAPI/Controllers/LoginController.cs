using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterAPI.Data;
using RegisterAPI.Model;

namespace RegisterAPI.Controllers
{
    //Error Occuring in Login API
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public class CustomeErrorResponse
        {
            public int Status { get; set; }
            public string Error { get; set; }
            public object Data { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<Login>> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var errorResponse = new CustomeErrorResponse
                    {
                        Status = 401,
                        Error = "Invalid Username or Password",
                        Data = null
                    };

                    var user = await _context.Register.FirstOrDefaultAsync(x => x.Username == login.Username && x.Password == login.Password);
                    if (user == null)
                    {
                        errorResponse.Error = "Username or Password is invalid";
                        return BadRequest(errorResponse);
                    }
                    if (user != null)
                    {
                        var response = new
                        {
                            Status = 200,
                            Message = "Login Successfull",
                            Data = login
                        };
                        return Ok(response);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
