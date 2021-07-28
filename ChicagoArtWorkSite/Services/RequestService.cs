using System;
using System.Net.Http;
using Newtonsoft.Json;
using Database.Entities;
using System.Threading.Tasks;
using ChicagoArtWorkSite.Models;
using System.Collections.Generic;
using System.Text;

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

        public async Task<IList<Artwork>> MakeRequestForArtWorks(int take)
        {
            List<Artwork> result = new List<Artwork>();

            if (take > 100)
            {
                for (int i = 0; i < take / 100; i++)
                {
                    result.AddRange(await ExecuteRequestForArt(100));
                }
                if (take % 100 != 0)
                {
                    result.AddRange(await ExecuteRequestForArt(take % 100));
                }
            }
            else
            {
                result.AddRange(await ExecuteRequestForArt(take));
            }
            return result;
        }

        private async Task<IList<Artwork>> ExecuteRequestForArt(int take)
        {
            var response = await Client.GetAsync($"artworks?limit={take}");

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<dynamic>(resultString);

            return Mapper.ToArtEntityBulk(responseObject);
        }
    }
}
