using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookShopController: ControllerBase
{
    private static readonly List<BookShop> _bookShops = new();

    [HttpGet]
    public IActionResult Get()
    {
        var result = _bookShops.Select(t => new { t.Id, t.Name, t.Adress }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var bookShop = _bookShops.Find(t => t.Id == id);

        var result = new
        {
            bookShop.Id,
            bookShop.Name,
            bookShop.Adress
        };

        return Ok(result);
    }

    [HttpDelete("{id}/delete")]
    public IActionResult Delete(int id)
    {
        var bookShop = _bookShops.First(t => t.Id == id);

        _bookShops.Remove(bookShop);

        return Ok();
    }

    [HttpPut("{id}/update")]
    public IActionResult Update(int id, [FromBody] CreateBookShopDto createDto)
    {
        var bookShop = _bookShops.Find(t => t.Id == id);
        _bookShops.Remove(bookShop);

        var newBookShop = new BookShop(bookShop.Id, createDto.Name, createDto.Adress);
        _bookShops.Add(newBookShop);

        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateBookShopDto createDto)
    {
        int id = _bookShops.Count() + 1;
        BookShop bookShop = new(id, createDto.Name, createDto.Adress);

        _bookShops.Add(bookShop);

        return Ok();
    }
}