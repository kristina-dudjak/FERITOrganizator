using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.SemesterService
{
    public class SemesterService : ISemesterService
    {
        private readonly HttpClient http;
        public List<SemesterData> Semesters { get; set; } = new List<SemesterData>();

        public SemesterService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadSemesters()
        {
            Semesters = await http.GetFromJsonAsync<List<SemesterData>>("api/Semester");
        }
    }
}
