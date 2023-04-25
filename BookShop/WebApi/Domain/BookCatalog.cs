namespace WebApi.Domain;
public class BookCatalog
{
    public int Id { get; init; }
    public int ShopId { get; init; }
    public int BookId { get; init; }
    public int Price { get; init; }
    public int Count { get; init; }
    public BookCatalog(int id, int shopId, int bookId, int price, int count)
    {
        Id = id;
        ShopId = shopId;
        BookId = bookId;
        Price = price;
        Count = count;
    }
}