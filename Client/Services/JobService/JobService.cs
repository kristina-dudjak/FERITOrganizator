using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.JobService
{
    public class JobService : IJobService
    {
        private readonly HttpClient http;
        public List<Job> Jobs { get; set; } = new List<Job>();

        public JobService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadJobs()
        {
            Jobs = await http.GetFromJsonAsync<List<Job>>("api/Job");
        }
    }
}
