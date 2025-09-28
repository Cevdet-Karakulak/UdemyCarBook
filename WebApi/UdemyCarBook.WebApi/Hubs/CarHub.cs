using Microsoft.AspNetCore.SignalR;
using System;

namespace UdemyCarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7124/api/Statistics/GetCarCount");
            var value = await responseMessage.Content.ReadAsStringAsync();
            var obj = System.Text.Json.JsonDocument.Parse(value);
            var count = obj.RootElement.GetProperty("carCount").GetInt32();

            await Clients.All.SendAsync("ReceiveCarCount", count); 
        }
    }
}
