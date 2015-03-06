using System;
using System.Security.Policy;
using System.Net.Http;
using RaportManager.Domian;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace RaportMaszynowy.Machine
{
    public class ApiManager
    {
        HttpClient client = new HttpClient();
        public string Url = "http://localhost:61471/";
        

        public void  SendItem(Item item)
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.PostAsJsonAsync("api/ItemApi", item);
            
        }

        public bool SendMachineStatus(MachineError error)
        {
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("api/ItemApi", error.Description).Result;
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public bool GetTaskSettings(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            string API = String.Concat("api/ItemApi/", id);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(API).Result;
            
            

            if (response.IsSuccessStatusCode)
            {
                Item item = response.Content.ReadAsAsync<Item>().Result;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
