using Database;
using Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Services
{
    public class ArtsServices : IArtsService
    {
        private ApplicationDbContext _context;
        private IRequestService _requestService;
        private readonly UserManager<IdentityUser> _manager;
        public ArtsServices(ApplicationDbContext context, IRequestService requestService, UserManager<IdentityUser> manager)
        {
            _context = context;
            _requestService = requestService;
            _manager = manager;
        }

        public async Task SeedData(int take)
        {
            if (_context.Artworks == null || !_context.Artworks.Any())
            {
                _context.Artworks.AddRange(await _requestService.MakeRequestForArtWorks(take));
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<Artwork>> GetArtworks(int take)
        {
            //I dont want to call ToListAsync here as to not load the data in memory until its needed by the view
            return await Task.Run(() => _context.Artworks.Take(take));
        }

        public async Task<IQueryable<Like>> GetLikes(IEnumerable<int> artworksIds, ClaimsPrincipal _user)
        {
            var user = await _manager.GetUserAsync(_user).ConfigureAwait(false);
            if (_context.Likes.Any())
            {
                return await Task.Run(() => _context.Likes?.Where(x => x.UserId == user.Id && artworksIds.Contains(x.ArtworkId)));
            }
            return null;
        }

        public async Task<bool> AddOrUpdateLike(bool like, int artworkID, ClaimsPrincipal _user)
        {
            var user = await _manager.GetUserAsync(_user).ConfigureAwait(false);
            if (!_context.Likes.Any())
            {
                return await AddLike(like, artworkID, user);
            }

            var likeRecord = _context.Likes.SingleOrDefault(x => x.ArtworkId == artworkID);
            if (likeRecord == null)
            {
                return await AddLike(like, artworkID, user);
            }

            likeRecord.ThumbsUp = like;
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AddLike(bool like, int artworkID, IdentityUser user)
        {
            try
            {
                _context.Likes.Add(new Like { UserId = user.Id, ArtworkId = artworkID, ThumbsUp = like });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
