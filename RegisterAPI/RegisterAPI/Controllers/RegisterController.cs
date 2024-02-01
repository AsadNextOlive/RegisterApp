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

        //Declaring StatusCode and Error
        public class CustomeErrorResponse
        {
            public int Status { get; set; }
            public string Error { get; set; }
            public object Data { get; set; }
        }

        //Post Method for storing data into the Database
        [HttpPost]
        public async Task<ActionResult<Register>> Register(Register register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Create a custome error response
                    var errorResponse = new CustomeErrorResponse
                    {
                        Status = 400,
                        Error = "",
                        Data = null
                    };

                    //Check if email already exist
                    var existingEmail = await _context.Register.FirstOrDefaultAsync(x => x.Email == register.Email);
                    if (existingEmail != null)
                    {
                        errorResponse.Error = "Email Already Exist";
                        return BadRequest(errorResponse);
                    }

                    _context.Register.Add(register);
                    await _context.SaveChangesAsync();

                    //Success response message
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
