using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelloWorld.SimpleWebsite.Models
{
    public class LoginModel :PageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
