using System.ComponentModel.DataAnnotations;

namespace WardrobeAPI.Models;

public class Garment
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Color { get; set; }
    public string? Description { get; set; }
    public string Material { get; set; }
}
