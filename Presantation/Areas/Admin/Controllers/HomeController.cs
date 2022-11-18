using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiinvestTravel.App.Constants;

namespace Presantation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = RoleConstants.Admin)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
