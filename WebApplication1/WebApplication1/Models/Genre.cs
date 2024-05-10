namespace WebApplication1.Models;

public class Genre
{
    public int PK { get; set; }
    public string Name { get; set; }
    public Genre(int pk, string name)
    {
        PK = pk;
        Name = name;
    }

}