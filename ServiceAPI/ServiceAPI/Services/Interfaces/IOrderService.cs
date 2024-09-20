using ServiceAPI.Models.DTO;

namespace ServiceAPI.Services.Interfaces;

public interface IOrderService
{
    List<OrderDto> GetAll();
    OrderDto GetByCode(int code);
    List<OrderDto> GetAllByClient(int client);
}