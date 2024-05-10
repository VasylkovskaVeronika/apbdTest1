using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IGenresRepository
{
    //public async Task<BookDTO>> GetProductsOutOfStock(string sortBy);
    public Task<Genre> GetGenreByID(int id);
    public Task<bool> DeleteGenreByID(int id);
}

public class GenresRepository: IGenresRepository
{
    private readonly IConfiguration _configuration;

    public GenresRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Genre> GetGenreByID(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteGenreByID(int id)
    {
        await using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();

        using SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText= "DELETE FROM GENRES WHERE PK=@gi";
        command.Parameters.AddWithValue("@gi", id);
        if (command.ExecuteNonQuery() > 0) //checking number of rows affected by query
        {
            return true;
        }

        return false;
    }
}