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

        public HttpClient _httpClient;
        public ApiRequester(string baseAdress)
        {
            _baseAdress = baseAdress;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseAdress);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public TResult Get<TResult>(string route, string token = null)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token);
            }

            using (HttpResponseMessage message = _httpClient.GetAsync(route).Result)
            {
                message.EnsureSuccessStatusCode();
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }

        public void Post<TEntity>(TEntity entity, string route, string token = null)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            string json = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage message = _httpClient.PostAsync(route, content).Result)
            {
                message.EnsureSuccessStatusCode();
                
            }
        }

        public void Put<TEntity>(TEntity entity, string route, string token = null)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            } 
            string json = JsonConvert.SerializeObject(entity);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage message = _httpClient.PutAsync(route, content).Result)
            {
                message.EnsureSuccessStatusCode();
            }
        }


        public void Delete(string route, string token = null)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            using (HttpResponseMessage message = _httpClient.DeleteAsync(route).Result)
            {
                message.EnsureSuccessStatusCode();
            }
        }
    }
}
