using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Services
{
    public interface IArtsService
    {
        Task SeedData(int take);

        Task<IQueryable<Artwork>> GetArtworks(int take);
    }
}
