using Microsoft.AspNetCore.Mvc.Rendering;
using RiinvestTravel.Data.Entities;

namespace Presantation.Areas.Admin.Models.UsersViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public bool PhoneNumberConfirmed { get; set; }
        public string RoleId { get; set; } = null!;
        public bool IsPictureDeleted { get; set; }

        public IFormFile? Picture { get; set; }

        public UserPicture? UserPicture { get; set; }

        public SelectList? Roles { get; set; }
    }
}
