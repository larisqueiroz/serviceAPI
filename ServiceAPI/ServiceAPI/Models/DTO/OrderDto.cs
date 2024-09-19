namespace ServiceAPI.Models.DTO;

public class OrderDto: BaseDto
{
    public int Code { get; set; }
    public List<ProductDto> Itens { get; set; }
    public ClientDto Client { get; set; }
    public int ClientCode { get; set; }
}