﻿using ServiceAPI.Repositories.Interfaces;
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

        var totalPrice = order.Itens.Sum(o => o.Price);

        return "R$ " + totalPrice.ToString();
    }

    public string GetOrdersQuantity(int clientCode)
    {
        var quantity = _orderService.GetAllByClient(clientCode).Count;

        return quantity.ToString() + " pedidos";
    }
}