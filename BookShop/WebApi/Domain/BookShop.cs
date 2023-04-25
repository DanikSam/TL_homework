namespace WebApi.Domain
{
    public class BookShop
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Adress { get; init; }
        public BookShop(int id, string name, string adress)
        {
            Id = id;
            Name = name;
            Adress = adress;
        }
    }
}
