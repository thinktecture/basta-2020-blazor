using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfToolAndMore.Server.Model;
using Microsoft.AspNetCore.SignalR;
using ConfToolAndMore.Server.Hubs;
using AutoMapper;
using ConfToolAndMore.Shared.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ConfToolAndMore.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly ConferencesDbContext _context;
        private readonly IHubContext<ConferencesHub> _hubContext;
        private readonly IMapper _mapper;

        public ConferencesController(ConferencesDbContext context, IHubContext<ConferencesHub> hubContext, IMapper mapper)
        {
            _context = context;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        // GET: api/Conferences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConferenceOverview>>> GetConferences()
        {
            var confs = await _context.Conferences.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<ConferenceOverview>>(confs));
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConferenceDetails>> GetConference(Guid id)
        {
            var conference = await _context.Conferences.FindAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            return _mapper.Map<Shared.DTO.ConferenceDetails>(conference);
        }

        // POST: api/Conferences
        [HttpPost]
        public async Task<ActionResult<ConferenceDetails>> PostConference(ConferenceDetails conference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var conf = _mapper.Map<Conference>(conference);
            
            _context.Conferences.Add(conf);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("NewConferenceAdded");

            return CreatedAtAction("GetConference", new { id = conference.ID }, conf);
        }
    }
}
