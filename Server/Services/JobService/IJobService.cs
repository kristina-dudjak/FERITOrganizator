using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.JobService
{
    public interface IJobService
    {
        Task<List<Job>> GetJobs();
    }
}
