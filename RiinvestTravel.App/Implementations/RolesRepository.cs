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
    public class RolesRepository : Repository<AspNetRole>, IRolesRepository
    {
        protected readonly DBRiinvestTravelContext _riinvestTravelDbContext;

        public RolesRepository(DBRiinvestTravelContext riinvestTravelDbContext) : base(riinvestTravelDbContext)
        {
            _riinvestTravelDbContext = riinvestTravelDbContext;
        }

        public AspNetRole? GetByStringId(string id)
        {
            return _riinvestTravelDbContext.AspNetRoles.FirstOrDefault(x => x.Id == id);
        }

        public AspNetRole? GetByUserId(string userId)
        {
            return _riinvestTravelDbContext.AspNetUsers.Include(x=> x.Roles).FirstOrDefault(x => x.Id == userId)?.Roles.FirstOrDefault();
        }
    }
}
