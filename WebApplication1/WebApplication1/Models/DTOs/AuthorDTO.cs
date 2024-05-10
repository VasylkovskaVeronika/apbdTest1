using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class AuthorDTO
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Surname { get; set; }

    public AuthorDTO(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
}