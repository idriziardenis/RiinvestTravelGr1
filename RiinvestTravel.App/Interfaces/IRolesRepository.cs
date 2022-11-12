﻿using RiinvestTravel.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiinvestTravel.App.Interfaces
{
    public interface IRolesRepository
    {
        AspNetRole? GetByUserId(string userId);
    }
}