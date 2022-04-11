using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiToolbox
{
    public class ApiRequester
    {
        private string _baseAdress;

        private HttpClient _httpClient;
        public ApiRequester(string baseAdress)
        {
            _baseAdress = baseAdress;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAdress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public TResult Get<TResult>(string route)
        {
           
                using (HttpResponseMessage message = _httpClient.GetAsync(route).Result)
                {
                    message.EnsureSuccessStatusCode();
                    string json = message.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<TResult>(json);
                }
            
        }

        public void Post()
        {

        }

        public void Put()
        {

        }

        public void Delete()
        {

        }
    }
}
