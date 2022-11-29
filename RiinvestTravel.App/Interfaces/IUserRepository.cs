using RiinvestTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUser>
    {
        AspNetUser? GetByStringId(string id);
        List<AspNetUser> GetAllWithRoles();
        UserPicture? GetUserPicture(string id);
        void DeleteUserPicture(UserPicture userPicture);
        void AddUserPicture(UserPicture userPicture);
    }
}
