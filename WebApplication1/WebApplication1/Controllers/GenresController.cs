using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")] //API/Genres
public class GenresController: ControllerBase
{
    private readonly IConfiguration _configuration;
    private IGenresRepository _repository;

    public GenresController(IConfiguration configuration, IGenresRepository repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    //DELETE api/genres/1 
        [HttpDelete("{id}", Name = "DelG")]
        public IActionResult DeleteAnimalById(int id)
        {
            if (_repository.DeleteGenreByID(id).Result)
                return StatusCode(204);
            return NotFound();
        }
    

   
}