using RaportManager.Domian;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RaportMaszynowy.Machine
{
    public class ApiManager
    {
        private HttpClient _client;
        public string Url = "http://localhost:244/";

        public ApiManager()
        {
            _client = new HttpClient { BaseAddress = new Uri(Url) };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SendItem(Item item)
        {
            var response = _client.PostAsJsonAsync("api/ItemApi/Create", item).Result;
            response.EnsureSuccessStatusCode();
        }

        public void ReportError()
        {
            HttpResponseMessage response = _client.GetAsync("api/MachineStatusApi/ReportError").Result;
            response.EnsureSuccessStatusCode();
        }

    
    }
}