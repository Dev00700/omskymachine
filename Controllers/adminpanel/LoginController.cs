using MachineWeb.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static MachineWeb.Models.UserLogin;

namespace MachineWeb.Controllers.adminpanel
{
    public class LoginController : Controller
    {
        private readonly UserLoginService _userLoginService;
        public LoginController(UserLoginService auserLoginService)
        {
            this._userLoginService = auserLoginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SaveLogin(UserLoginRequest userLoginRequest)
        {
            var res = await _userLoginService.Login(userLoginRequest.Username, userLoginRequest.Password);
            if(res != null)
            {
                if (res.Flag == 1)
                {
                    HttpContext.Session.SetString("UserGuid", res.Data.UserGuid.ToString() ?? "");
                    return Json(new { success = true, message = res.Message });
                }
                else
                {
                    return Json(new { success = false, message = res.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            return Json(new { success = false, message = "Something went wrong" });
        }
    }
}
