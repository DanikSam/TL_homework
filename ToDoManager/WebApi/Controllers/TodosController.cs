using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Controllers;

// TODO: добавить методы получения по Id, изменения по Id, удаления по Id
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private static readonly List<Todo> _todos = new();

    /// <summary>
    /// Возвращает все Todo
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Get()
    {
        // Анонимный тип
        var result = _todos.Select(t => new { t.Id, t.Title, plannedDay = t.PlannedDay.ToString("yyyy-MM-dd hh:mm:ss") }).ToList();
        
        return Ok(result);
    }

    /// <summary>
    /// Возвращает Todo по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var todo = _todos.Find(t => t.Id == id);

        var result = new
        {
            todo.Id,
            todo.Title,
            plannedDay = todo.PlannedDay.ToString("yyyy-MM-dd hh:mm:ss")
        };

        return Ok(result);
    }

    [HttpDelete("{id}/delete")]
    public IActionResult Delete(int id)
    {
        var todo = _todos.First(t => t.Id == id);

        _todos.Remove(todo);

        return Ok();
    }

    [HttpPut("{id}/update")]
    public IActionResult Update(int id, [FromBody] CreateTodoDto createDto)
    {
        var todo = _todos.Find(t => t.Id == id);
        _todos.Remove(todo);

        var newTodo = new Todo(todo.Id, createDto.Title, todo.PlannedDay);
        _todos.Add(newTodo);

        return Ok();
    }

    /// <summary>
    /// Создаёт Todo
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create([FromBody] CreateTodoDto createDto)
    {
        int id = _todos.Count() + 1;
        Todo todo = new(id, createDto.Title);
        
        _todos.Add(todo);

        return Ok();
    }
}
