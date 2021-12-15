using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FERITOrganizator.Shared;
using FERITOrganizator.Shared.Models;

namespace FERITOrganizator.Client.Services.MenuService
{
    interface IMenuService
    {
        List<Menu> Menus { get; set; }
        Task LoadMenus();
    }
}
