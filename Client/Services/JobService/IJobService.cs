using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.JobService
{
    interface IJobService
    {
        List<Job> Jobs { get; set; }
        Task LoadJobs();
    }
}
