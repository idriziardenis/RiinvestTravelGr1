using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RiinvestTravel.App.Constants;

namespace Presantation.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Authorize(Roles = RoleConstants.Admin)]
    public class HomeController : Controller
    {
        private IOptions<RequestLocalizationOptions> _options;
        private IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor, IOptions<RequestLocalizationOptions> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _options = options;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetLanguage(string culture)
        {
            try
            {
                var cultureItems = _options.Value.SupportedUICultures!.Select(x => x.Name).ToArray();
                if (cultureItems.Any(x => x.Equals(culture)))
                {
                    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), HttpOnly = true, Secure = _httpContextAccessor.HttpContext!.Request.IsHttps });
                }
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
