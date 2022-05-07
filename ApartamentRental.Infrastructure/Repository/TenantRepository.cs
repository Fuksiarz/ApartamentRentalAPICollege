using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class TenantRepository : ITenantRepository
{
    private readonly MainContext _mainContext;
    public TenantRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public Task<IEnumerable<Tenant>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Tenant entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}