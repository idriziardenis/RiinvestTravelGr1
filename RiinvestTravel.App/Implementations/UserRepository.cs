using Microsoft.EntityFrameworkCore;
using RiinvestTravel.App.Interfaces;
using RiinvestTravel.Data.Context;
using RiinvestTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Implementations
{
    public class UserRepository : Repository<AspNetUser>, IUserRepository
    {
        protected readonly DBRiinvestTravelContext _riinvestTravelDbContext;
        public UserRepository(DBRiinvestTravelContext riinvestTravelDbContext) : base(riinvestTravelDbContext)
        {
            _riinvestTravelDbContext = riinvestTravelDbContext;
        }

        public AspNetUser? GetByStringId(string id)
        {
            return _riinvestTravelDbContext.AspNetUsers.FirstOrDefault(x => x.Id == id);
        }

        public List<AspNetUser> GetAllWithRoles()
        {
            return _riinvestTravelDbContext.AspNetUsers.Include(x => x.Roles).ToList();
        }

        public UserPicture? GetUserPicture(string id)
        {
            return _riinvestTravelDbContext.AspNetUsers.Include(x => x.Picture).FirstOrDefault(x => x.Id == id)?.Picture;
        }

        public void DeleteUserPicture(UserPicture userPicture)
        {
            _riinvestTravelDbContext.UserPictures.Remove(userPicture);
            _riinvestTravelDbContext.SaveChanges();
        }

        public void AddUserPicture(UserPicture userPicture)
        {
            _riinvestTravelDbContext.UserPictures.Add(userPicture);
            _riinvestTravelDbContext.SaveChanges();
        }
    }
}
