using FERITOrganizator.Server.Services.JobService;
using FERITOrganizator.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Job>>> GetJobs()
        {
            return Ok(await jobService.GetJobs());
        }
    }
}
