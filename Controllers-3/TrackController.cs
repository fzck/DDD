using System;
using Music3.Application;
using Microsoft.AspNetCore.Mvc;

namespace FedApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller")]
    public class TrackController : Controller
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public IActionResult GetAllTracks()
        {
            return Json(_trackService.GetAllTracks());
        }
    }
}