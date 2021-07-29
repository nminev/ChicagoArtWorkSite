using ChicagoArtWorkSite.Data;
using ChicagoArtWorkSite.Models;
using ChicagoArtWorkSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ChicagoArtWorkSite.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<GalleryController> _logger;

        private readonly IArtsService _artService;

        public GalleryController(ILogger<GalleryController> logger, IArtsService artsService)
        {
            _logger = logger;
            _artService = artsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy(int page = 1)
        {
            var result = await _artService.GetArtworks(100);

            var likes = await _artService.GetLikes(result.Select(x => x.Id), HttpContext.User);
            IList<GalleryViewModel> test = Mapper.ToGalleryModelViewBulk(result, likes);
            return View(test.ToPagedList(page, pageSize: 12)); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
