using egitimPortali.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace egitimPortali.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly EducationContext _context;

        public EducationsController(EducationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEducations()
        {
            var educations = await _context.Educations.ToListAsync();
            return Ok(educations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducation(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEducationById), new { id = education.Id }, education);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationById(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducation(int id, Education education)
        {
            if (id != education.Id)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Educations.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
