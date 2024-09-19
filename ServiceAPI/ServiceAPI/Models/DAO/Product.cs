namespace ServiceAPI.Models.DAO;

public class Product: Base
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}