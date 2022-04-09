using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{

    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public Task<IEnumerable<Apartment>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Apartment> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}