using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGroup1Android.models;
using WebAppStudents.Configurations;

namespace APIGroup1Android.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentdetialsController : ControllerBase
    {
        private readonly Agentcontext _context;
        NotificationHubConfiguration standardNotificationHubConfiguration;

        public AgentdetialsController(Agentcontext context)
        {
            _context = context;
            standardNotificationHubConfiguration = new NotificationHubConfiguration();
            standardNotificationHubConfiguration.ConnectionString = "Endpoint=sb://haoli638.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=gA4gEqhoT9/0AGbMGJI8wGwBL+dw9cXD9oDAny6qG1Y=";
            standardNotificationHubConfiguration.HubName = "PushNotificationDemoJuly2020 ";
        }

        // GET: api/Agentdetials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agentdetial>>> GetAgentdetials()
        {
            return await _context.Agentdetials.ToListAsync();
        }

        // GET: api/Agentdetials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agentdetial>> GetAgentdetial(int id)
        {
            var agentdetial = await _context.Agentdetials.FindAsync(id);

            if (agentdetial == null)
            {
                return NotFound();
            }

            return agentdetial;
        }

        // PUT: api/Agentdetials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgentdetial(int id, Agentdetial agentdetial)
        {
            if (id != agentdetial.id)
            {
                return BadRequest();
            }

            _context.Entry(agentdetial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentdetialExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agentdetials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Agentdetial>> PostAgentdetial(Agentdetial agentdetial)
        {
            _context.Agentdetials.Add(agentdetial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgentdetial", new { id = agentdetial.id }, agentdetial);
        }

        // DELETE: api/Agentdetials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agentdetial>> DeleteAgentdetial(int id)
        {
            var agentdetial = await _context.Agentdetials.FindAsync(id);
            if (agentdetial == null)
            {
                return NotFound();
            }

            _context.Agentdetials.Remove(agentdetial);
            await _context.SaveChangesAsync();

            return agentdetial;
        }

        private bool AgentdetialExists(int id)
        {
            return _context.Agentdetials.Any(e => e.id == id);
        }
    }
}
