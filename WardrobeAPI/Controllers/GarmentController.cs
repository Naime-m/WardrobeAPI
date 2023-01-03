using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WardrobeAPI.Data;

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

}
