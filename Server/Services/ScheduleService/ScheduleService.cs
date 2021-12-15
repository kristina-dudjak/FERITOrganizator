using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FERITOrganizator.Server.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private static readonly HttpClient http;
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
        
        static ScheduleService()
        {
            http = new HttpClient();
            http.BaseAddress = new Uri("http://mrkve.etfos.hr/");
        }

        public void GenerateWeek()
        {
            DateTime weekStart = DateTime.Today.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)DateTime.Today.DayOfWeek);

            List<string> week = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                week.Add(weekStart.AddDays(i).ToString("yyyy-MM-dd"));
            }

            foreach (string day in week)
            {
               Schedules.Add(GetScheduleAsync("api/raspored/index.php?date=" + day).Result);
                Debug.WriteLine("0");
            }

        }
        private async Task<Schedule> GetScheduleAsync(string url)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                HttpResponseMessage response = http.GetAsync(url).Result;
                var xmlString = response.Content.ReadAsStringAsync().Result;
                var buffer = Encoding.GetEncoding("Windows-1250").GetBytes(xmlString);

                using (var stream = new MemoryStream(buffer))
                {
                    var serializer = new XmlSerializer(typeof(Schedule));
                    return (Schedule)serializer.Deserialize(stream);
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return new Schedule();
            }
        }
           
       

        public async Task<List<Schedule>> GetSchedules()
        {
            GenerateWeek();
            return Schedules;
        }
    }
}
