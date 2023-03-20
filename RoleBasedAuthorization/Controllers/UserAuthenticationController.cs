using Microsoft.AspNetCore.Mvc;

namespace RoleBasedAuthorization.Controllers
{
    public class UserAuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
