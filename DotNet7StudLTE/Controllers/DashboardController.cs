using Microsoft.AspNetCore.Mvc;

namespace INVENTORY6.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
