using System.ComponentModel.DataAnnotations;

namespace RegisterAPI.Model
{
    public class Register
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
