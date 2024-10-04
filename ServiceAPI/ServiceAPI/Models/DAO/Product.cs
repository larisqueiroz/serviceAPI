namespace ServiceAPI.Models.DAO;

public class Product: Base
{
    public Type Type { get; set; }
    public int Quantity { get; set; }
}