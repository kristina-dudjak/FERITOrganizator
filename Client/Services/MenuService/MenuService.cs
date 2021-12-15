using FERITOrganizator.Shared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.MenuService
{
    public class MenuService:IMenuService
    {
        private readonly HttpClient http;
        public List<Menu> Menus { get; set; } = new List<Menu>();

        public MenuService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadMenus()
        {
            Menus = await http.GetFromJsonAsync<List<Menu>>("api/Menu");
        }
    }
}
