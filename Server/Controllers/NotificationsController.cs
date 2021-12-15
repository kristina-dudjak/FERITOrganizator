using FERITOrganizator.Server.Models;
using FERITOrganizator.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebPush;

namespace FERITOrganizator.Server.Controllers
{
    [Route("notifications")]
    [ApiController]
    public class NotificationsController : Controller
    {
        private readonly OrganizatorContext db;

        public NotificationsController(OrganizatorContext db)
        {
            this.db = db;
        }

        [HttpPut("subscribe")]
        public async Task<NotificationSubscription> Subscribe(NotificationSubscription subscription)
        {
            var userId = "a";
            var oldSubscriptions = db.NotificationSubscriptions.Where(e => e.UserId == userId);
            db.NotificationSubscriptions.RemoveRange(oldSubscriptions);

            subscription.UserId = userId;
            if(oldSubscriptions.Count() == 0)
            {
                await db.NotificationSubscriptions.AddAsync(subscription);
            }
            else
            {
                db.NotificationSubscriptions.Attach(subscription);
            }

            await db.SaveChangesAsync();
            return subscription;
        }
    }
}
