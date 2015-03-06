using RaportManager.Domian;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RaportMaszynowy.Machine
{
    public class ApiManager
    {
        private HttpClient _client;
        public string Url = "http://localhost:61471/";

        public ApiManager()
        {
            _client = new HttpClient { BaseAddress = new Uri(Url) };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SendItem(Item item)
        {
            var response = _client.PostAsJsonAsync("api/ItemApi", item).Result;
            response.EnsureSuccessStatusCode();
        }

        public void ReportError()
        {
            HttpResponseMessage response = _client.GetAsync("api/MachineStatusApiController").Result;
            response.EnsureSuccessStatusCode();
        }

        public Settings GetTaskSettings()
        {
            var response = _client.GetAsync("api/ItemSettingsApi/GetActive").Result;
            Settings settings = response.Content.ReadAsAsync<Settings>().Result;
            return settings;
        }
    }
}