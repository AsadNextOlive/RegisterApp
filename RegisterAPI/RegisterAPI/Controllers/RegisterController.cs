using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterAPI.Data;
using RegisterAPI.Model;

namespace RegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Register
        [HttpGet]
        public ActionResult<IEnumerable<Register>> GetRegister()
        {
            try
            {
                var registeredUser = _context.Register.ToList();
                return Ok(registeredUser);
            }
            catch (Exception)
            {
                var errorResponse = new CustomerErrorResponse
                {
                    Status = 500,
                    Error = "Internal Server Error",
                    Data = null
                };
                return StatusCode(500, errorResponse);
            }
        }


        //Declaring Success and Error Code
        public class CustomerErrorResponse
        {
            public int Status { get; set; }
            public string Error { get; set; }
            public object Data { get; set;}
        }

        // POST: api/Register
        [HttpPost]
        public async Task<ActionResult<Register>> Register(Register register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Custome Error Message
                    var errorResponse = new CustomerErrorResponse
                    {
                        Status = 400,
                        Error = "",
                        Data = null
                    };

                    //If email already exist
                    var existingEmail = await _context.Register.FirstOrDefaultAsync(x => x.Email == register.Email);
                    if (existingEmail != null)
                    {
                        errorResponse.Error = "Email Already Exist";
                        return BadRequest(errorResponse);
                    }
                    _context.Register.Add(register);
                    await _context.SaveChangesAsync();

                    //Success message
                    var response = new
                    {
                        Status = 200,
                        Message = "Registration Successfull",
                        Data = register
                    };
                    return Created("", response);
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
