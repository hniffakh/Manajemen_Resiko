using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Resiko.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
