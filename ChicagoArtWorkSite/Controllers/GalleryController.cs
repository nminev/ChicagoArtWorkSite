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

namespace ChicagoArtWorkSite.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<GalleryController> _logger;

        private readonly IRequestService _requestService;

        public GalleryController(ILogger<GalleryController> logger, IRequestService requestService)
        {
            _logger = logger;
            _requestService = requestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var test = await _requestService.GetRepos();
            
            return View(test);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
