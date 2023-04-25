namespace WebApi.Domain;

public class Book
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Author { get; init; }

    public Book(int id, string name, string author)
    {
        Id = id;
        Name = name;
        Author = author;
    }
}