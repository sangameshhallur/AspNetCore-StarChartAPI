using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;
using StarChart.Models;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        CelestialObject celestialObject = new CelestialObject();
        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {            
            if (_context.CelestialObjects.Contains(id))
            {
                return NotFound();
            }

            celestialObject.Satellites = _context.CelestialObjects.Where(a => a.Id.Equals(id)).ToList();
            return Ok(celestialObject.Satellites);

        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            if (_context.CelestialObjects.Contains(name))
            {
                return NotFound();
            }

            celestialObject.Satellites = _context.CelestialObjects.Where(a=> a.Name.Equals(name)).ToList();
            return Ok(celestialObject.Satellites);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            celestialObject.Satellites = _context.CelestialObjects.ToList();
            return Ok(celestialObject.Satellites);
        }
    }
}
