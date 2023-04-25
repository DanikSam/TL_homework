using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private static readonly List<Book> _book = new();

    [HttpGet]
    public IActionResult Get()
    {
        var result = _book.Select(t => new { t.Id, t.Name, t.Author }).ToList();
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var book = _book.Find(t => t.Id == id);

        var result = new
        {
            book.Id,
            book.Name,
            book.Author
        };

        return Ok(result);
    }

    [HttpDelete("{id}/delete")]
    public IActionResult Delete(int id)
    {
        var book = _book.First(t => t.Id == id);

        _book.Remove(book);

        return Ok();
    }

    [HttpPut("{id}/update")]
    public IActionResult Update(int id, [FromBody] CreateBookDto createDto)
    {
        var book = _book.Find(t => t.Id == id);
        _book.Remove(book);

        var newBook = new Book(book.Id, createDto.Name, createDto.Author);
        _book.Add(newBook);

        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookDto createDto)
    {
        int id = _book.Count() + 1;
        Book book = new(id, createDto.Name, createDto.Author);
        
        _book.Add(book);

        return Ok();
    }
}
