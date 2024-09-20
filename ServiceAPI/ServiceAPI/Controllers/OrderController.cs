using Microsoft.AspNetCore.Mvc;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;
using ServiceAPI.Utils;

namespace ServiceAPI.Controllers;

[ApiController]
[Route("orders")]
public class OrderController: ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IClientService _clientService;
    private OrderTotal orderTotal;
    public OrderController(IOrderService OrderService, IClientService clientService)
    {
        _orderService = OrderService;
        _clientService = clientService;
        orderTotal = new OrderTotal(_orderService, _clientService);
    }

    [HttpGet]
    public ActionResult<List<OrderDto>> GetAll()
    {
        try
        {
            return _orderService.GetAll();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("by-code")]
    public ActionResult<OrderDto> GetByCode([FromQuery] int code)
    {
        try
        {
            return _orderService.GetByCode(code);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("by-client-code")]
    public ActionResult<List<OrderDto>> GetByClientCode([FromQuery] int code)
    {
        try
        {
            return _orderService.GetAllByClient(code);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("price-by-order")]
    public ActionResult<string> GetPriceByOrder([FromQuery] int code)
    {
        try
        {
            return orderTotal.GetOrderPrice(code);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("orders-by-client")]
    public ActionResult<string> GetOrdersQuantity([FromQuery] int clientCode)
    {
        try
        {
            return orderTotal.GetOrdersQuantity(clientCode);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}