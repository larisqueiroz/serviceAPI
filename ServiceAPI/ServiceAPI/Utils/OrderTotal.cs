using ServiceAPI.Repositories.Interfaces;
using ServiceAPI.Services.Interfaces;

namespace ServiceAPI.Utils;

public class OrderTotal
{
    private readonly IOrderService _orderService;
    private readonly IClientService _clientService;
    
    public OrderTotal(IOrderService orderService, IClientService clientService)
    {
        _orderService = orderService;
        _clientService = clientService;
    }

    public string GetOrderPrice(int code)
    {
        var order = _orderService.GetByCode(code);
        double totalPrice = 0;

        foreach (var item in order.Itens)
        {
            totalPrice += item.Type.Price * item.Quantity;
        }

        return "R$ " + String.Format("{0:F2}", totalPrice);
    }

    public string GetOrdersQuantity(int clientCode)
    {
        var quantity = _orderService.GetAllByClient(clientCode).Count;

        return quantity.ToString() + " pedidos";
    }
}