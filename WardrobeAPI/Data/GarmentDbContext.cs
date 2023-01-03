using Microsoft.EntityFrameworkCore;
using WardrobeAPI.Models;

namespace WardrobeAPI.Data;

public class GarmentDbContext : DbContext
{
	public GarmentDbContext(DbContextOptions<GarmentDbContext> options) : base(options)
	{

	}

	DbSet<Garment> Garments {get; set; }
}
