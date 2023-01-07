using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chatApp.Controllers
{
    public class ChatController : Controller
    {
        [Authorize]
        public IActionResult Chat()
        {
            TempData["user"] = User.Identity.Name;
            return View();
        }
    }
}
