using FERITOrganizator.Shared.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.MenuService
{
    public class MenuService : IMenuService
    {
        private static readonly string C_url = "http://www.stucos.unios.hr/upload/jelovnik_campusTVweb.html";
        private static readonly string I_url = "http://www.stucos.unios.hr/upload/jelovnik_istarskaTVweb.html";
        public List<Menu> Menus { get; set; }


        public MenuService()
        {
            Menus = new List<Menu>();
            Menus.Add(new Menu());
            Menus[0].Name = "Restoran Istarska";
            Menus[0].Categories = GetCategories(I_url);
            Menus.Add(new Menu());
            Menus[1].Name = "Restoran Campus";
            Menus[1].Categories = GetCategories(C_url);
        }

        public async Task<List<Menu>> GetMenus()
        {
            return Menus;
        }

        public List<MenuCategory> GetCategories(string url)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(@"C:\Users\KristinaPC\source\repos\FERITOrganizator\FERITOrganizator\Server\bin\Debug\netcoreapp3.1",options);
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(50);

            List<MenuCategory> menuCategories = new List<MenuCategory>();
            var categories = driver.FindElements(By.XPath("/html/body/table/tr"));
            int i = 1;
            foreach(var category in categories)
            {
                var title = driver.FindElement(By.XPath("/html/body/table/tr[" + i + "]/td[1]"));
                var meals = driver.FindElement(By.XPath("/html/body/table/tr[" + i + "]/td[2]"));
                MenuCategory menuCategory = new MenuCategory() { Title = title.Text, Meals = meals.Text };
                menuCategories.Add(menuCategory);
                i++;
            }
            return menuCategories;
        }
    }
}
