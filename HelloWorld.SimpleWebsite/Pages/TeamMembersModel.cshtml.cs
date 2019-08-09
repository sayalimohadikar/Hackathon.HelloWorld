using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class TeamMembersModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Members in the Team.";
        }
    }
}
