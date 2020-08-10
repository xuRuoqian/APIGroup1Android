using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIGroup1Android.models;
using APIGroup1Android.Configurations;

namespace APIGroup1Android.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly usercontext _context;
        NotificationHubConfiguration standardNotificationHubConfiguration;

        public usersController(usercontext context)
        {
            _context = context;
            standardNotificationHubConfiguration = new NotificationHubConfiguration();
            standardNotificationHubConfiguration.ConnectionString = "Endpoint=sb://ruoqianxu.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=GQFrRQ/CJE0SA9gpp1+tB6YW09MvaiLs90r5x54X/AI=";
            standardNotificationHubConfiguration.HubName = "PushNotificationDemoIct638";
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getuser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putuser(int id, user user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
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

        // POST: api/users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(user user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            Console.WriteLine("User with id:{0} created", user.id);
            return CreatedAtAction("Getuser", new { id = user.id }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<user>> Deleteuser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool userExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
