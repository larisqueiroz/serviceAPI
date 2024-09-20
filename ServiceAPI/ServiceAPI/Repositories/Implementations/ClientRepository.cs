using ServiceAPI.Data;
using ServiceAPI.Models.DAO;
using ServiceAPI.Repositories.Interfaces;

namespace ServiceAPI.Repositories.Implementations;

public class ClientRepository: IClientRepository
{
    private readonly ServiceAPIContext _ctx;
    
    public ClientRepository(ServiceAPIContext ctx)
    {
        _ctx = ctx;
    }

    public List<Client> GetAll()
    {
        return _ctx.Clients.ToList();
    }

    public Client GetByCode(int code)
    {
        return _ctx.Clients.FirstOrDefault(c => c.Code == code);
    }

    public void Save(Client client)
    {
        _ctx.Clients.Add(client);
        _ctx.SaveChanges();
    }
}