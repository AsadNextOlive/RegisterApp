using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
            public object Data { get; set; }
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
                        Message = "Registration Successful",
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



        //DELETE: api/Register/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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

                    var register = _context.Register.Find(id);

                    if (register == null)
                    {
                        errorResponse.Error = "Please enter valid UserId";
                        return BadRequest(errorResponse);
                    }

                    _context.Register.Remove(register);
                    _context.SaveChanges();

                    //Success message
                    var response = new
                    {
                        Status = 200,
                        Message = "Deleted Successfully",
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



        //UPDATE: api/Register/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Register updateRegister)
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

                    var existingUser = _context.Register.Find(id);
                    if (existingUser == null)
                    {
                        errorResponse.Error = "Please enter valid UserId";
                        return BadRequest(errorResponse);
                    }

                    existingUser.Username = updateRegister.Username;
                    existingUser.Password = updateRegister.Password;
                    existingUser.Email = updateRegister.Email;
                    existingUser.Phone = updateRegister.Phone;

                    _context.Register.Update(existingUser);
                    _context.SaveChanges();

                    //Success message
                    var response = new
                    {
                        Status = 200,
                        Message = "Updated Successfully",
                        Data = existingUser
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



        //GET:api/register/search - Filter by email
        [HttpGet("search")]
        public async Task<IActionResult> registeredUserByEmail(string email)
        {
            
            try
            {
                //Custome Error Message
                var errorResponse = new CustomerErrorResponse
                {
                    Status = 400,
                    Error = "",
                    Data = null
                };

                var register = await _context.Register.FirstOrDefaultAsync(e => e.Email == email);

                if (register == null)
                {
                    errorResponse.Error = "Please enter valid Email";
                    return BadRequest(errorResponse);
                }

                //Success message
                var response = new
                {
                    Status = 200,
                    Message = "Found Successfully",
                    Data = register
                };

                return Created("", response);

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
    }
}
