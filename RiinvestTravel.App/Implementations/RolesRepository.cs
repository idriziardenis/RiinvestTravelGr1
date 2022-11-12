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
    public class RolesRepository : IRolesRepository
    {
        protected readonly DBRiinvestTravelContext _riinvestTravelDbContext;

        public RolesRepository(DBRiinvestTravelContext riinvestTravelDbContext)
        {
            _riinvestTravelDbContext = riinvestTravelDbContext;
        }

        public AspNetRole? GetByUserId(string userId)
        {
            return _riinvestTravelDbContext.AspNetUsers.FirstOrDefault(x => x.Id == userId)?.Roles.FirstOrDefault();
        }
    }
}
