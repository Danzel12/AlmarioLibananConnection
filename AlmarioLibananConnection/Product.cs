// Product class
class Product
{
    public int Id;
    public string Name;
    public int Quantity;
    public decimal Price;
    public string Category;

    public Product(int id, string name, int quantity, decimal price, string category)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
        Price = price;
        Category = category;
    }
}
