using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Resiko.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
