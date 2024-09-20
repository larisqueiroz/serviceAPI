using ServiceAPI.Models.DAO;

namespace ServiceAPI.Repositories.Interfaces;

public interface IOrderRepository
{
    List<Order> GetAll();
    Order GetByCode(int code);
    List<Order> GetAllByClient(int client);
    void Save(Order order);
}