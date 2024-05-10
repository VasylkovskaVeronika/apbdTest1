using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")] //API/Books
public class BooksController: ControllerBase
{
    private readonly IConfiguration _configuration;
    private IBooksRepository _repository;

    public BooksController(IConfiguration configuration, IBooksRepository repository)
    {
        _configuration = configuration;
        _repository = repository;
    }
    //GET api/books/1 
    [HttpGet("{id}", Name = "GetB")]
    public IActionResult GetAnimals([FromQuery] int id)
    {
        var res = _repository.GetBookInfoById(id);
        return Ok(res);
    }

    
    
}