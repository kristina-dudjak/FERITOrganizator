using FERITOrganizator.Server.Models;
using FERITOrganizator.Server.Pages;
using FERITOrganizator.Server.Services;
using FERITOrganizator.Server.Services.CourseService;
using FERITOrganizator.Server.Services.JobService;
using FERITOrganizator.Server.Services.MenuService;
using FERITOrganizator.Server.Services.ScheduleService;
using FERITOrganizator.Server.Services.SemesterService;
using FERITOrganizator.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FERITOrganizator.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyMethod());
            });


            services.AddDbContext<OrganizatorContext>(option =>
                option.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Organizator;Integrated Security=True"));

            services.AddControllersWithViews();

            services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("https://localhost:44397/"));

            services.Configure<GzipCompressionProviderOptions>(options=>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddRazorPages();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<ICourseService, CourseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

        
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseResponseCompression();

            app.UseCors("open");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
