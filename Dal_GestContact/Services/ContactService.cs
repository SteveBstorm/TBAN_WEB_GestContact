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
    public class ContactService : IContactRepo
    {
        //public IEnumerable<Contact> GetAll()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7089/api/");

        //        using (HttpResponseMessage message = client.GetAsync("Contact").Result)
        //        {

        //            message.EnsureSuccessStatusCode();

        //            string json = message.Content.ReadAsStringAsync().Result;

        //            IEnumerable<Contact> contacts = JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);

        //            //foreach (Contact contact in contacts)
        //            //{
        //            //    yield return contact;
        //            //}
        //            if (contacts is null)
        //                throw new Exception("Aucun contact à afficher");

        //            return contacts;


        //        }
        //    }
        //}

        private readonly string _baseAdress = "https://localhost:7089/api/";
        private ApiRequester requester;
        public ContactService()
        {
            requester = new ApiRequester(_baseAdress);
        }

        public IEnumerable<Contact> GetAll()
        {
            return requester.Get<IEnumerable<Contact>>("Contact");
        }

        public Contact GetById(int Id)
        {
            return requester.Get<Contact>("Contact/" + Id);
        }

        //public Contact GetById(int Id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7089/api/");

        //        using (HttpResponseMessage message = client.GetAsync("Contact/" + Id).Result)
        //        {

        //            message.EnsureSuccessStatusCode();

        //            string json = message.Content.ReadAsStringAsync().Result;

        //            Contact contacts = JsonConvert.DeserializeObject<Contact>(json);


        //            if (contacts is null)
        //                throw new Exception("Aucun contact à afficher");

        //            return contacts;


        //        }
        //    }
        //}


        public void Post(Contact c)
        {
            requester.Post(c, "Contact");
        }
        //public void Post(Contact c)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7089/api/");

        //        string json = JsonConvert.SerializeObject(c);
        //        HttpContent content = new StringContent(json);

        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        using (HttpResponseMessage message = client.PostAsync("Contact", content).Result)
        //        {
        //            message.EnsureSuccessStatusCode();


        //        }
        //    }
        //}

        //public void Delete(int Id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7089/api/");


        //        using (HttpResponseMessage message = client.DeleteAsync("Contact/" + Id).Result)
        //        {
        //            message.EnsureSuccessStatusCode();
        //        }
        //    }
        //}

        public void Delete(int Id)
        {
            requester.Delete("Contact/" + Id);
        }

        //public void Update(Contact c)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7089/api/");

        //        string json = JsonConvert.SerializeObject(c);
        //        HttpContent content = new StringContent(json);

        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        using (HttpResponseMessage message = client.PutAsync("Contact/" + c.Id, content).Result)
        //        {
        //            message.EnsureSuccessStatusCode();
        //        }
        //    }
        //}

        public void Update(Contact c)
        {
            requester.Put(c, "Contact/" + c.Id);
        }
    }
}
