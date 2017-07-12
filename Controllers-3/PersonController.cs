using Music3.Application;
using Music3.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FedApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/persons")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

   
         public PersonController(IPersonService personService)
         {
            _personService = personService;
         }

        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDto personDto)
        {
            try
            {
                _personService.CreatePerson(personDto);
            }catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            try
            {
                _personService.DeletePerson(id);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServiceError);
            }
            return HttpStatusCodeResult(StatusCodes.Status200OK);
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Json(_personService.GetAllPersons());
        }

    }
}