using Microsoft.AspNetCore.Mvc;

namespace MachineWeb.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}
