using FERITOrganizator.Server.Models;
using FERITOrganizator.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebPush;

namespace FERITOrganizator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly OrganizatorContext db;
        public NotesController(OrganizatorContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public object Get()
        {
            var items = new { Items = db.Notes, Count = db.Notes.Count() };
            return items;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public object Get(long id)
        {
            return new { Items = db.Notes.Where(x => x.NoteId.Equals(id)).FirstOrDefault(), Count = db.Notes.Count() };
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task PostAsync([FromBody] Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
            SendNotificationAsync(note, "Bilješka uspješno dodana!");
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Note note)
        {
            Note note1 = db.Notes.Where(x => x.NoteId.Equals(id)).FirstOrDefault();
            note1.Name = note.Name;
            note1.IsDone = note.IsDone;
            note1.Due = note.Due;
            db.SaveChanges();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Note note1 = db.Notes.Where(x => x.NoteId.Equals(id)).FirstOrDefault();
            db.Notes.Remove(note1);
            db.SaveChanges();
        }

        private void SendNotificationAsync(Note note, string message)
        {
            var publicKey = "BHuK26TYzUurBWf9TM7bnjduiaVG7mQPb5aPhfHRkx67mrJlfWTIdDToZleroitXdYHfnbF30zHTE09HjP3yjFw";
            var privateKey = "3vSzPSv7HPpJET9CCxIt8UYtOvxA7DO32_Ofjq01gtI";

            var subscription = db.NotificationSubscriptions.Where(e => e.UserId == "a").SingleOrDefaultAsync().Result;
            var pushSubscription = new PushSubscription(subscription.Url, subscription.P256dh, subscription.Auth);
            var vapidDetails = new VapidDetails("mailto: <someone@example.com>", publicKey, privateKey);
            var webPushClient = new WebPushClient();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    message = message
                });
                webPushClient.SendNotification(pushSubscription, payload, vapidDetails);
            }
            catch (WebPushException ex)
            {
                Console.Error.WriteLine("Error sending push notification: " + ex.Message);
            }
        }
    }
}
