﻿using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.MenuService
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenus();
    }
}
