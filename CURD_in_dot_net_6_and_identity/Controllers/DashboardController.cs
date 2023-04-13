using Microsoft.AspNetCore.Mvc;

namespace CURD_in_dot_net_6_and_identity.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
