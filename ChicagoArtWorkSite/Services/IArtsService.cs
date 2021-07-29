using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Services
{
    public interface IArtsService
    {
        Task SeedData(int take);

        Task<IQueryable<Artwork>> GetArtworks(int take);
        Task<IQueryable<Like>> GetLikes(IEnumerable<int> artworksIds, ClaimsPrincipal _user);

        Task<bool> AddOrUpdateLike(bool like, int artworkID, ClaimsPrincipal _user);
    }
}
