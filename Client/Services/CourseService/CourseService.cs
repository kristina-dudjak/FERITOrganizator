using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.CourseService
{
    public class CourseService:ICourseService
    {
        private readonly HttpClient http;
        public List<CourseData> Courses { get; set; } = new List<CourseData>();

        public CourseService(HttpClient http)
        {
            this.http = http;
        }

        public async Task LoadCourses()
        {
            Courses = await http.GetFromJsonAsync<List<CourseData>>("api/Course");
        }
    }
}
