using ApiToolbox;
using Dal_GestContact.Entities;
using Dal_GestContact.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dal_GestContact.Services
{
    public class UserService : IUserRepo
    {
        private readonly ApiRequester _requester;
        private readonly string _baseAdress = "https://localhost:7089/api/";
        public UserService()
        {
            _requester = new ApiRequester(_baseAdress);
        }

        public string Login(string email, string password)
        {
            string json = JsonConvert.SerializeObject(new { email = email, password = password });
            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage message = _requester._httpClient.PostAsync("Auth", content).Result)
            {
                try
                {
                    message.EnsureSuccessStatusCode();
                        string response = message.Content.ReadAsStringAsync().Result;

                        return response;
                 
                }
                catch (Exception ex)
                {
                    throw new Exception(message.Content.ReadAsStringAsync().Result);
                }
                
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _requester.Get<IEnumerable<User>>("User");
        }

        public User GetById(int Id, string token)
        {
            return _requester.Get<User>("User/" + Id, token);
        }
    }
}
