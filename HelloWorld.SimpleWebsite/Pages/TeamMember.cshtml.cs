using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class TeamMemberModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Team Mates !!!";
        }
    }
}
