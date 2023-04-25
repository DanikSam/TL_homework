namespace WebApi.Dto
{
    public class CreateBookCatalogDto
    {
        public int ShopId { get; init; }
        public int BookId { get; init; }
        public int Price { get; init; }
        public int Count { get; init; }
    }
}
