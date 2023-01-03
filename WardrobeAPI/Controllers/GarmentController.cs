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
}
