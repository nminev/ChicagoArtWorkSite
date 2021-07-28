using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChicagoArtWorkSite.Services
{
    public class ArtsServices : IArtsService
    {
        private ApplicationDbContext _context;
        private IRequestService _requestService;

        public ArtsServices(ApplicationDbContext context, IRequestService requestService)
        {
            _context = context;
            _requestService = requestService;
        }

        public async Task SeedData(int take)
        {
            if (_context.Artworks == null || !_context.Artworks.Any())
            {
                _context.Artworks.AddRange(await _requestService.MakeRequestForArtWorks(take));
                _context.SaveChanges();
            }
        }

        public async Task<IQueryable<Artwork>> GetArtworks(int take)
        {
            //I dont want to call ToListAsync here as to not load the data in memory until its needed by the view
            return await Task.Run(()=>_context.Artworks.Take(take));
        }
    }
}
