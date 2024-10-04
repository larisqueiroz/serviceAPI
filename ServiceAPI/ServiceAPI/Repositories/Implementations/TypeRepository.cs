using ServiceAPI.Data;
using ServiceAPI.Models.DAO;
using ServiceAPI.Repositories.Interfaces;
using Type = ServiceAPI.Models.DAO.Type;

namespace ServiceAPI.Repositories.Implementations;

public class TypeRepository: ITypeRepository
{
    private readonly ServiceAPIContext _ctx;
    
    public TypeRepository(ServiceAPIContext ctx)
    {
        _ctx = ctx;
    }

    public List<Type> GetAll()
    {
        return _ctx.Types.ToList();
    }

    public Type GetById(Guid id)
    {
        return _ctx.Types.FirstOrDefault(c => c.Id == id);
    }
    
    public Type GetByName(string name)
    {
        return _ctx.Types.FirstOrDefault(c => c.Name == name);
    }
    
    public void Save(Type Type)
    {
        _ctx.Types.Add(Type);
        _ctx.SaveChanges();
    }
}