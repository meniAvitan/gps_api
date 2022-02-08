using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mySqlConnectionDemo.Data;

namespace mySqlConnectionDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LocationController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            return await _context.Location.ToListAsync();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Location.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpGet("routeId/{routeId}")]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations(string routeId)
        {
            var routes = _context.Location.Where(location => location.RouteId == routeId).AsEnumerable();
           

            if (routes == null)
            {
                return NotFound();
            }

            return new OkObjectResult(routes);
        }

        // PUT: api/Location/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPut("{routeId}")]
        public async Task<IActionResult> PutLocation([FromBody] IEnumerable<Location> location, string routeId)
        {

            var res = _context.Location.Where(x => x.RouteId == routeId).FirstOrDefault();
            if (res != null)
            {

                foreach (var item in location)
                {
                    if (routeId != item.RouteId)
                    {
                        return BadRequest();
                    }
                    _context.Entry(item).State = EntityState.Modified;
                }
            }
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(routeId))
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
*/
        private bool LocationExists(string routeId)
        {
            throw new NotImplementedException();
        }

        // POST: api/Location
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation([FromBody] IEnumerable< Location> location)
        {
           foreach(var item in location)
            {
                _context.Location.Add(item);
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location }, location);
        }


        [HttpPut("routeId/{routeId}")]
        public async Task<ActionResult<Location>> UpdateLocation([FromBody] List<Location> location, string routeId)
        {
            var res = _context.Location.Where(x => x.RouteId == routeId).ToList();
            
            if (res != null)
            {
                for (int i = 0; i < location.Count(); i++)
                {
                    res[i].Lat = location[i].Lat;
                    res[i].Lng = location[i].Lng;
                }
                
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Location.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Location.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.Id == id);
        }
    }
}
