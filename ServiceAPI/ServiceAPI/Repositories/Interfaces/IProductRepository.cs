using ServiceAPI.Models.DAO;

namespace ServiceAPI.Repositories.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(Guid id);
    void Save(Product product);
}