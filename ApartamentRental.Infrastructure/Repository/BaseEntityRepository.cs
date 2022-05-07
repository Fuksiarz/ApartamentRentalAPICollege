using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class BaseEntityRepository :IBaseEntityRepository
{
    private readonly MainContext _mainContext;
    public BaseEntityRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public Task<IEnumerable<BaseEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<BaseEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(BaseEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(BaseEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}