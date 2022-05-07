using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class ImageRepository : IImageRepository
{
    private readonly MainContext _mainContext;
    public ImageRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public Task<IEnumerable<Image>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Image> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Image entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}