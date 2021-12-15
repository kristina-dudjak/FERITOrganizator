using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FERITOrganizator.Shared.Models
{
    public partial class Menu 
    {
        public string Name { get; set; }
        public List<MenuCategory> Categories { get; set; }

    }
}
