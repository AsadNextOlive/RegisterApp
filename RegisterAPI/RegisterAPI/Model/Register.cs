using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace RegisterAPI.Model
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
