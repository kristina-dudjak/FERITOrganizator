using FERITOrganizator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FERITOrganizator.Client.Services
{
    public class NotesClient
    {
        private readonly HttpClient httpClient;

        public NotesClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await httpClient.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }


    }
}
