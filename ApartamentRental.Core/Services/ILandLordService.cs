using ApartamentRental.Core.DTO;

namespace ApartamentRental.Core.Services;

public interface ILandLordService
{
    Task<Task> CreateNewLandlordAccountAsync(LandLordCreationRequestDto dto);
}