using RiinvestTravel.App.Interfaces;
using RiinvestTravel.Models.KeyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Implementations
{
    public class SelectListService : ISelectListService
    {
        private readonly IRolesRepository rolesRepository;

        public SelectListService(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IEnumerable<KeyValueItem> GetRolesKeysValues()
        {
            try
            {
                var roles = rolesRepository.GetAll().ToList();
                var result = roles.Select(role => new KeyValueItem()
                {
                    SKey = role.Id,
                    Value = role.Name ?? ""
                });

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
