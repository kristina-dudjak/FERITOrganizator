using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.CourseService
{
    interface ICourseService
    {
        List<CourseData> Courses { get; set; }
        Task LoadCourses();
    }
}
