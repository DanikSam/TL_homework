using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookCatalogController: ControllerBase
{ 
    private static readonly List<BookCatalog> _bookCatalog = new ();

    [HttpGet]
    public IActionResult Get()
    {
        var result = _bookCatalog.Select(t => new { t.Id, t.ShopId, t.BookId, t.Price, t.Count }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var bookCatalog = _bookCatalog.Find(t => t.Id == id);

        var result = new
        {
            bookCatalog.Id,
            bookCatalog.ShopId,
            bookCatalog.BookId,
            bookCatalog.Price,
            bookCatalog.Count
        };

        return Ok(result);
    }

    [HttpDelete("{id}/delete")]
    public IActionResult Delete(int id)
    {
        var bookCatalog = _bookCatalog.First(t => t.Id == id);

        _bookCatalog.Remove(bookCatalog);

        return Ok();
    }

    [HttpPut("{id}/update")]
    public IActionResult Update(int id, [FromBody] CreateBookCatalogDto createDto)
    {
        var bookCatalog = _bookCatalog.Find(t => t.Id == id);
        _bookCatalog.Remove(bookCatalog);

        var newBookCatalog = new BookCatalog(bookCatalog.Id, createDto.ShopId, createDto.BookId, createDto.Price, createDto.Count);
        _bookCatalog.Add(newBookCatalog);

        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookCatalogDto createDto)
    {
        int id = _bookCatalog.Count() + 1;
        BookCatalog bookCatalog = new(id, createDto.ShopId, createDto.BookId, createDto.Price, createDto.Count);

        _bookCatalog.Add(bookCatalog);

        return Ok();
    }
}