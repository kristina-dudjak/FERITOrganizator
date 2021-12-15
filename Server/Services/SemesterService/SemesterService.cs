using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Server.Services.SemesterService
{
    public class SemesterService : ISemesterService
    {
        public async Task<List<SemesterData>> GetSemesters()
        {  
            List<SemesterData> Semesters = new List<SemesterData>
            {
                    new SemesterData(){ Category = "1. godina", Number = 1},
                    new SemesterData(){ Category = "1. godina", Number = 2},
                    new SemesterData(){ Category = "2. godina", Number = 3},
                    new SemesterData(){ Category = "2. godina", Number = 4},
                    new SemesterData(){ Category = "3. godina", Number = 5},
                    new SemesterData(){ Category = "3. godina", Number = 6}
             };
            return Semesters;
        }
    }
}
