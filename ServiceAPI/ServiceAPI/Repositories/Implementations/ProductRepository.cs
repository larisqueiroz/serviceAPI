using ServiceAPI.Data;
using ServiceAPI.Models.DAO;
using ServiceAPI.Repositories.Interfaces;

namespace ServiceAPI.Repositories.Implementations;

public class ProductRepository: IProductRepository
{
    private readonly ServiceAPIContext _ctx;
    
    public ProductRepository(ServiceAPIContext ctx)
    {
        _ctx = ctx;
    }

    public List<Product> GetAll()
    {
        return _ctx.Products.ToList();
    }

    public Product GetById(Guid id)
    {
        return _ctx.Products.FirstOrDefault(c => c.Id == id);
    }
    
    public void Save(Product product)
    {
        _ctx.Products.Add(product);
        _ctx.SaveChanges();
    }
}