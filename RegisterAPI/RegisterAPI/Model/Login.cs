using Microsoft.EntityFrameworkCore;

namespace RegisterAPI.Model
{
    [Keyless]
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isLoggedIn { get; set; }
    }
}
