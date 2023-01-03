using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Data;
using WardrobeAPI.Models;

namespace WardrobeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GarmentController : ControllerBase
{
    private readonly GarmentDbContext _context;

    public GarmentController(GarmentDbContext context)
    {
        _context = context;
    }

    [HttpGet]

    public async Task<IEnumerable<Garment>> Get()
    {
        return await _context.Garments.ToListAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Garment), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var garment = await _context.Garments.FindAsync(id);
        return garment == null ? NotFound() : Ok(garment);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(Garment garment)
    {
        await _context.Garments.AddAsync(garment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = garment.Id }, garment);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<IActionResult> Update(int id, Garment garment)
    {
        if (id != garment.Id)
        {
            return BadRequest();
        }

        _context.Entry(garment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<IActionResult> Delete(int id)
    {
        var garmentToDelete = await _context.Garments.FindAsync(id);
        if (garmentToDelete == null)
        {
            return NotFound();
        }
        
        _context.Garments.Remove(garmentToDelete);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
