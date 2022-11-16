using Microsoft.AspNetCore.Mvc;
using RiinvestTravel.App.Interfaces;

namespace Presantation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUsersJson()
        {
            var users = userRepository.GetAll();

            var result = users.Select(x => new
            {
                id = x.Id,
                name = x.Name,
                surname = x.Surname,
                email = x.Email,
                emailConfirmed = x.EmailConfirmed
            });

            return new JsonResult(result);
        }
    }
}
