using CURD_in_dot_net_6_and_identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CURD_in_dot_net_6_and_identity.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationContext _context;

        public DashboardController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Employee.ToList();
            return View(data);
        }
    }
}
