using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class BookDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public List<GenreDTO> Genres { get; set; }
    [Required]
    public List<AuthorDTO> Authors { get; set; }

    public BookDTO(int id, string name, List<GenreDTO> genres, List<AuthorDTO> authors)
    {
        Id = id;
        Name = name;
        Genres = genres;
        Authors = authors;
    }
}