using FERITOrganizator.Shared.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.JobService
{
    public class JobService : IJobService
    {
        private static readonly string url = "https://www.facebook.com/pg/Studentski-servis-Osijek-Studentski-centar-u-Osijeku-138315679674425/posts/";

        public List<Job> Jobs { get; set; }

        public JobService()
        {
            Jobs = new List<Job>();
            GetText(url);
        }

        public async Task<List<Job>> GetJobs()
        {
            return Jobs;
        }

        private void GetText(string url)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            ChromeOptions options = new ChromeOptions();

            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 1);
            options.AddUserProfilePreference("profile.cookie_controls_mode", 1);
            options.AddArgument("--headless");
            options.AddArguments("--disable-extensions"); 
            options.AddArguments("--disable-notifications");
            options.AddArguments("--disable-application-cache"); 
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            options.AddExcludedArgument("enable-automation");

            IWebDriver driver = new ChromeDriver(@"C:\Users\KristinaPC\source\repos\FERITOrganizator\FERITOrganizator\Server\bin\Debug\netcoreapp3.1",options);
            driver.Navigate().GoToUrl(url);
            
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div/div/div/div[3]/button[2]")).Click(); //accept cookies

            var posts = driver.FindElements(By.CssSelector("div.text_exposed_root"));
            
            foreach (var post in posts)
            {
                var text = post.FindElement(By.CssSelector("p"));
                Jobs.Add(new Job() {Text= text.Text});
            }
        }
    }
}
