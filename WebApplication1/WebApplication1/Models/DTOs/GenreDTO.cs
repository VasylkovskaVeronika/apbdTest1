using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class GenreDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public GenreDTO(string name)
    {
       
        Name = name;
    }

}