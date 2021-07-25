using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Services
{
    public class RequestService : IRequestService
    {
        public string GetAll()
        {
            using var httpClient = new HttpClient();


            return "";
        }
    }
}
