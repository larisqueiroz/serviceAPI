namespace ServiceAPI.Models.DTO;

public class ProductDto: BaseDto
{
    public TypeDto Type { get; set; }
    public int Quantity { get; set; }
}