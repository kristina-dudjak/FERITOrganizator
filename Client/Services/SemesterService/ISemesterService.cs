using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.SemesterService
{
    interface ISemesterService
    {
        List<SemesterData> Semesters { get; set; }
        Task LoadSemesters();
    }
}
