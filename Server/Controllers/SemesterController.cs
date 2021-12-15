using FERITOrganizator.Shared.Models;
using FERITOrganizator.Server.Services.SemesterService;
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
    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SemesterData>>> GetSemesters()
        {
            return Ok(await semesterService.GetSemesters());
        }
    }
}
