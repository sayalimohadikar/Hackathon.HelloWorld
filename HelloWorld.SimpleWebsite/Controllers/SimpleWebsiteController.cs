using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.SimpleWebsite.Controllers
{
    /// <inheritdoc />
    [Route("/Simple")]
    public class SimpleWebsiteController : Controller
    {
        public const string HackButtonId = "hackButton";

        [HttpGet]
        [Route("Main")]
        public IActionResult MainView()
        {
            return View();
        }
    }
}
