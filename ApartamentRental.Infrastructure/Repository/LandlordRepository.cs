using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class LandlordRepository : ILandlordRepository
{
    private readonly MainContext _mainContext;
    public LandlordRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    
    public Task<IEnumerable<Landlord>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Landlord> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Landlord entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}