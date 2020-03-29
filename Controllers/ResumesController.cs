using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desree.Models;

namespace Desree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly DesreeDbContext _context;

        public ResumesController(DesreeDbContext context)
        {
            _context = context;
        }

        // GET: api/Resumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resume>>> GetResume()
        {
            return await _context.Resume.ToListAsync();
        }

        // GET: api/Resumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resume>> GetResume(int id)
        {
            var resume = await _context.Resume.FindAsync(id);

            if (resume == null)
            {
                return NotFound();
            }

            return resume;
        }

        // PUT: api/Resumes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResume(int id, Resume resume)
        {
            if (id != resume.Id)
            {
                return BadRequest();
            }

            _context.Entry(resume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumeExists(id))
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

        // POST: api/Resumes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Resume>> PostResume(Resume resume)
        {
            _context.Resume.Add(resume);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResume", new { id = resume.Id }, resume);
        }

        // DELETE: api/Resumes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resume>> DeleteResume(int id)
        {
            var resume = await _context.Resume.FindAsync(id);
            if (resume == null)
            {
                return NotFound();
            }

            _context.Resume.Remove(resume);
            await _context.SaveChangesAsync();

            return resume;
        }

        private bool ResumeExists(int id)
        {
            return _context.Resume.Any(e => e.Id == id);
        }
    }
}
