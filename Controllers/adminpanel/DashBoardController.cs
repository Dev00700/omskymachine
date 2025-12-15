using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers.adminpanel
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
