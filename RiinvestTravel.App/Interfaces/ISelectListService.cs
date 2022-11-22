using RiinvestTravel.Models.KeyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Interfaces
{
    public interface ISelectListService
    {
        IEnumerable<KeyValueItem> GetRolesKeysValues();
    }
}
