using ChicagoArtWorkSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChicagoArtWorkSite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IArtsService _artService;
        public LikeController(IArtsService artsService)
        {
            _artService = artsService;
        }

        // POST api/LikeController/1
        [HttpPost]
        public async Task Post(bool like, int artworkID)
        {
            bool success = await _artService.AddOrUpdateLike(like, artworkID,HttpContext.User);
            
        }

        //// PUT api/<ValuesController>/5
        //[HttpPut]
        //public async Task Put(bool like, int artworkID)
        //{
        //    bool success = await _artService.AddOrUpdateLike(like, artworkID, HttpContext.User);
        //}
    }
}
