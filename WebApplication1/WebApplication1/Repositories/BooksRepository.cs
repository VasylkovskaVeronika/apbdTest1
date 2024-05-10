using Microsoft.Data.SqlClient;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Repositories;

public interface IBooksRepository
{
    public Task<BookDTO> GetBookInfoById(int id);
    public Task<List<GenreDTO>> GetGenresByID(int id);
    public Task<List<AuthorDTO>> GetAuthorsByID(int id);
    
}

public class BooksRepository: IBooksRepository
{
    private readonly IConfiguration _configuration;

    public BooksRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<BookDTO> GetBookInfoById(int id)
    {
        await using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")); 
        conn.Open();

        using SqlCommand command = new SqlCommand("select title from books where PK=@id;", conn);
        command.Parameters.AddWithValue("@id", id);
        String resultSet = (String)command.ExecuteScalar();
        BookDTO book = new BookDTO(id, resultSet, GetGenresByID(id).Result, GetAuthorsByID(id).Result);
        return book;
    }

    public async Task<List<GenreDTO>> GetGenresByID(int id)
    {
        await using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")); 
        conn.Open();

        using SqlCommand command = new SqlCommand("SELECT name from genres join books_genres on PK=FK_genre where FK_book=@id;", conn);
        command.Parameters.AddWithValue("@id", id);

        var reader = command.ExecuteReader();

        List<GenreDTO> res = new List<GenreDTO>();
        int nameOfOrdinal = reader.GetOrdinal(("name"));

        while (reader.Read())
        {
            res.Add(new GenreDTO(
                reader.GetString(nameOfOrdinal)
            ));
        }

        return res;
    }
    public async Task<List<AuthorDTO>> GetAuthorsByID(int id)
    {
        await using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")); 
        conn.Open();

        using SqlCommand command = new SqlCommand("select first_name, last_name from authors join books_authors on PK=FK_author where FK_book=@id;", conn);
        command.Parameters.AddWithValue("@id", id);

        var reader = command.ExecuteReader();

        List<AuthorDTO> res = new List<AuthorDTO>();
        int nameOfOrdinal = reader.GetOrdinal(("first_name"));
        int surnameOfOrdinal = reader.GetOrdinal(("last_name"));

        while (reader.Read())
        {
            res.Add(new AuthorDTO(
                reader.GetString(nameOfOrdinal),
                reader.GetString(surnameOfOrdinal)
            ));
        }

        return res;
    }
    }