using ServiceAPI.Models.DAO;

namespace ServiceAPI.Models.DTO;

public class MessageReceived
{
    public int CodigoPedido { get; set; }
    public int CodigoCliente { get; set; }
    public List<ItemDto> Itens { get; set; } = new List<ItemDto>();
}