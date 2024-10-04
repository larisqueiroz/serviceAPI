using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAPI.Data;
using ServiceAPI.Models.DAO;
using ServiceAPI.Repositories.Interfaces;

namespace ServiceAPI.Repositories.Implementations;

public class OrderRepository: IOrderRepository
{
    private readonly ServiceAPIContext _ctx;
    
    public OrderRepository(ServiceAPIContext ctx)
    {
        _ctx = ctx;
    }

    public List<Order> GetAll()
    {
        return _ctx.Orders.Include(o => o.Client)
            .Include(o => o.Itens).ToList();
    }

    public Order GetByCode(int code)
    {
        return _ctx.Orders.Include(o => o.Client)
            .Include(o => o.Itens).FirstOrDefault(c => c.Code == code);
    }

    public Order GetByClient(int client, int orderCode)
    {
        return _ctx.Orders.Include(o => o.Client)
            .Include(o => o.Itens).FirstOrDefault(o => o.Client.Code == client && o.Code == orderCode);
    }
    
    public List<Order> GetAllByClient(int client)
    {
        return _ctx.Orders.Include(o => o.Client)
            .Include(o => o.Itens).Where(o => o.Client.Code == client).ToList();
    }
    
    public void Save(Order order)
    {
        _ctx.Orders.Add(order);
        _ctx.SaveChanges();
    }
}