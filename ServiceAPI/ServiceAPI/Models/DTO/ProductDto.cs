namespace ServiceAPI.Models.DTO;

public class ProductDto: BaseDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}