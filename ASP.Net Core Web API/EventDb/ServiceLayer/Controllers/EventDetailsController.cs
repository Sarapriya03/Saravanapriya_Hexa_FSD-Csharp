using System.Diagnostics;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")] //http://localhost:5022/api/v2.0/EventDetails/
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailsRepo<EventDetails> _eventDetailsRepo;
        private readonly IConfiguration _configuration;
        public EventDetailsController(IEventDetailsRepo<EventDetails> eventDetailsRepo, IConfiguration configuration)
        {
            this._eventDetailsRepo = eventDetailsRepo;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllEvents()
        {
            var events = _eventDetailsRepo.GetAllEvents();
            if (events != null)
            {
                return Ok(events);//Ok:200
            }
            else
            {
                return NotFound();//NotFound:404
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetEventsById(int id)
        {
            var eventById = _eventDetailsRepo.GetEventsById(id);
            if (eventById != null)
            {
                return Ok(eventById);//Ok:200
            }
            else
            {
                return NotFound();//NotFound:404
            }
        }

        [HttpPost]
        [Route("SaveEvent")]
        public IActionResult AddEvent([FromBody] EventDetails eventDetails)
        {
            if (eventDetails != null)
            {
                _eventDetailsRepo.AddEvent(eventDetails);
                return Created(HttpContext.Request.Path, eventDetails);//Created:201
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var delEvent = _eventDetailsRepo.DeleteEvent(id);
            if (delEvent != null)
            {
                return Ok(delEvent);//Ok:200
            }
            else
            {
                return BadRequest();//NotFound:404
            }
        }

        [HttpPut]
        [Route("UpdateEvent")]
        public IActionResult UpdateEvent([FromBody] EventDetails eventDetails)
        {
            var updatedEvent = _eventDetailsRepo.UpdateEvent(eventDetails);
            if (updatedEvent != null)
            {
                return Accepted(HttpContext.Request.Path, updatedEvent);//Created:202
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
