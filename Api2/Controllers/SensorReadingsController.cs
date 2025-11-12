// Controllers/SensorReadingsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api2.Data;
using Api2.Models;

namespace Api2.Controllers
{
    // Route pattern: /api/sensorreadings
    [ApiController]
    [Route("api/[controller]")]
    public class SensorReadingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Dependency-injected database context
        public SensorReadingsController(AppDbContext context)
        {
            _context = context;
        }

        // ---------------------------------------------------------
        // POST: /api/sensorreadings
        // Adds a new sensor reading record
        // ---------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AddReading([FromBody] SensorReading reading)
        {
            // Basic validation
            if (reading == null || string.IsNullOrWhiteSpace(reading.SensorId))
                return BadRequest("Invalid reading data.");

            reading.Timestamp = DateTime.UtcNow;

            _context.SensorReadings.Add(reading);
            await _context.SaveChangesAsync();

            // Returns 201 Created + location header
            return CreatedAtAction(nameof(GetReadingById),
                                   new { id = reading.Id },
                                   reading);
        }

        // ---------------------------------------------------------
        // GET: /api/sensorreadings
        // Returns all stored readings
        // ---------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorReading>>> GetAllReadings()
        {
            var readings = await _context.SensorReadings
                                         .OrderByDescending(r => r.Timestamp)
                                         .ToListAsync();
            return Ok(readings);
        }

        // ---------------------------------------------------------
        // GET: /api/sensorreadings/{id}
        // Returns a single reading by Id
        // ---------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorReading>> GetReadingById(int id)
        {
            var reading = await _context.SensorReadings.FindAsync(id);
            if (reading == null)
                return NotFound();

            return Ok(reading);
        }

        [HttpGet("stats")]
        public async Task<ActionResult<IEnumerable<object>>> GetStats()
        {
            var stats = await _context.SensorReadings
                .GroupBy(r => r.SensorId)
                .Select(g => new
                {
                    SensorId = g.Key,
                    Min = g.Min(x => x.Value),
                    Max = g.Max(x => x.Value),
                    Avg = g.Average(x => x.Value)
                })
                .ToListAsync();
            return Ok(stats);
        }
        
    }
}
