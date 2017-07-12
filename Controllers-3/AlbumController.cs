using System;
using System.Collections.Generic;
using System.Linq;

using Music3.Infrastructure;
using Music3.Application;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FedApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public IActionResult GetAllTracks()
        {
            return Json(_albumService.GetAllAlbums());
        }
    }
}