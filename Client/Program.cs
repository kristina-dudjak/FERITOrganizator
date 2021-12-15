using HtmlAgilityPack;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FERITOrganizator.Shared.Models;
using FERITOrganizator.Client.Services.MenuService;
using FERITOrganizator.Client.Services.JobService;
using FERITOrganizator.Client.Services.ScheduleService;
using FERITOrganizator.Client.Services;
using FERITOrganizator.Client.Services.SemesterService;
using FERITOrganizator.Client.Services.CourseService;

namespace FERITOrganizator.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDg3NjU5QDMxMzkyZTMyMmUzMGszZ0ZMTGVVcHFjNkVxeGdtb2syalF6Z05rY29RaDdwUWVCTzdEbUUxRGM9");
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<NotesClient>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<ISemesterService, SemesterService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            await builder.Build().RunAsync();
        }
    }
}
