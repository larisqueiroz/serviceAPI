using ServiceAPI.Models.DAO;

namespace ServiceAPI.Repositories.Interfaces;

public interface IClientRepository
{
    List<Client> GetAll();
    Client GetByCode(int code);
    void Save(Client client);
}