using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly HttpClient http;
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();

        public ScheduleService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadSchedules()
        {

            Schedules = await http.GetFromJsonAsync<List<Schedule>>("api/Schedule");
        }
    }
}
