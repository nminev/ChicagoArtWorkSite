using System;
using System.Net.Http;
using Newtonsoft.Json;
using Database.Entities;
using System.Threading.Tasks;
using ChicagoArtWorkSite.Models;
using System.Collections.Generic;


namespace ChicagoArtWorkSite.Services
{
    public class RequestService : IRequestService
    {
        private HttpClient Client { get; }

        public RequestService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.artic.edu/api/v1/");

            Client = client;
        }
        public async Task<IList<Artwork>> GetRepos()
        {
            var response = await Client.GetAsync("artworks");

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<dynamic>(resultString);

            List<Artwork> test =  Mapper.ToArtEntityBulk(responseObject);

           


            return test;
        }
    }
}
