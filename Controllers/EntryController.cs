using Microsoft.AspNetCore.Mvc;
using Entry.Data;
using Entry.Models;

namespace Entry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.EntryInfos.ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] EntryInfo info)
        {
            _context.EntryInfos.Add(info);
            _context.SaveChanges();
            return Created($"api/entry/{info.Id}", info);
        }
    }
}