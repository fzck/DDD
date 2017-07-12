using System;
using Music3.Application;
using Music3.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music3.Infrastructure.Cross_Cutting.LoggingFactory;


namespace FedApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/artists")]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly ILogger log = FedLogger.CreateLogger<ArtistController>();

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpPost]
        public IActionResult CreateArtist([FromBody] ArtistDto artist)
        {
            try
            {
                _artistService.CreateArtist(artist);
            }
            catch (ArgumentException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(long id)
        {
            try
            {
                _artistService.DeleteArtist(id);
            }
            catch (ArgumentException)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }

            return Ok(StatusCodes.Status200OK);
        }

        [HttpGet]
        public IActionResult GetAllArtists()
        {
            return Json(_artistService.GetAllArtists());
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(long id)
        {
            try
            {
                return Json(_artistService.GetArtistById(id));
            }
            catch (ArgumentException e)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize("artist.read")]
        [HttpGet("{id}/tracks")]
        public IActionResult GetArtistTracks(long id)
        {
            return Json("");
        }

        [Authorize("artist.modify")]
        [HttpGet("{id}/add_track_to_artist")]
        public IActionResult AddTrackToArtist(long id, [FromBody] TrackDto trackDto)
        {
            try
            {
                _artistService.AddTrackToArtist(id, trackDto);
            }
            catch(ArgumentException e)
            {
                log.LogError("Error on addind a new track." + e.Message);
                return NotFound(StatusCodes.Status404NotFound);
            }

            return Ok(StatusCodes.Status200OK);
        }



        [HttpPut("{id}")]
        public IActionResult UpdateArtistInfo(long id, [FromBody] ArtistDto artistDto)
        {
            try
            {
                _artistService.ModifyArtist(id, artistDto);
            }
            catch (ArgumentException e)
            {
                log.LogError("Error on updating author: " + e.Message);
                return NotFound(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(StatusCodes.Status200OK);
        }
    }
 }