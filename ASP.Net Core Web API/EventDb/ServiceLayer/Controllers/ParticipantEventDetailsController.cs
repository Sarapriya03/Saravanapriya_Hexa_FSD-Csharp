using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")] //http://localhost:5022/api/v3.0/ParticipantEventDetails/
    [ApiController]
    public class ParticipantEventDetailsController : ControllerBase
    {
        private readonly IParticipantEventDetailsRepo<ParticipantEventDetails> _participantRepo;
        private readonly IConfiguration _configuration;


        public ParticipantEventDetailsController(IParticipantEventDetailsRepo<ParticipantEventDetails> participantRepo, IConfiguration configuration)
        {
            this._participantRepo = participantRepo;
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllParticipantEventDetails()
        {
            var list = _participantRepo.GetAllParticipantEventDetails();
            if (list != null && list.Any())
            {
                return Ok(list); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetParticipantEventDetailsById(int id)
        {
            var participant = _participantRepo.GetParticipantEventDetailsById(id);
            if (participant != null)
            {
                return Ok(participant); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult AddParticipantEventDetails([FromBody] ParticipantEventDetails participant)
        {
            if (ModelState.IsValid)
            {
                var created = _participantRepo.AddParticipantEventDetails(participant);
                return Created(HttpContext.Request.Path, created); // 201
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateParticipantEventDetails([FromBody] ParticipantEventDetails participant)
        {
            if (ModelState.IsValid)
            {
                var updated = _participantRepo.UpdateParticipantEventDetails(participant);
                if (updated != null)
                    return Accepted(HttpContext.Request.Path, updated); // 202
                else
                    return NotFound(); // 404
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteParticipantEventDetails(int id)
        {
            var deleted = _participantRepo.DeleteParticipantEventDetails(id);
            if (deleted != null)
            {
                return Ok(deleted); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }
    }
}
