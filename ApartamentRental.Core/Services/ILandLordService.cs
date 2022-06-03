using ApartamentRental.Core.DTO;

namespace ApartamentRental.Core.Services;

public interface ILandLordService
{
    Task<bool> CreateNewLandlordAccountAsync(LandLordCreationRequestDto dto);
}