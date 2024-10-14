using Type = ServiceAPI.Models.DAO.Type;

namespace ServiceAPI.Repositories.Interfaces;

public interface ITypeRepository
{
    List<Type> GetAll();
    Type GetById(Guid id);
    Type GetByName(string name);
    void Save(Type Type);
}