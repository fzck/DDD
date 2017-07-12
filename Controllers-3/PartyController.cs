using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music3.Application;
using Music3.Presentation;



namespace FedApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/parties")]
    public class PartyController : Controller
    {
        private readonly IPartyService _partyService;

        public PartyController(IPartyService partyService)
        {
            _partyService = partyService;
        }

        [HttpPost]
        public IActionResult CreateParty([FromBody] PartyDto partyDto)
        {
            try
            {
                _partyService.CreateParty(partyDto);
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteParty(long id)
        {
            try
            {
                _partyService.DeleteParty(id);
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return StatusCode(StatusCodes.Status200OK);
        }



    }
}