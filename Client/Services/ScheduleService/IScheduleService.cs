using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services.ScheduleService
{
    interface IScheduleService
    {
        List<Schedule> Schedules { get; set; }
        Task LoadSchedules();
    }
}
