using ApartamentRental.Core.DTO;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using ApartamentRental.Infrastructure.Repository;

namespace ApartamentRental.Core.Services;

public class LandLordService : ILandLordService
{
    
    private readonly ILandlordRepository _landLordRepository;
    
    private readonly AccountRepository _accountRepository;
    
    public LandLordService( ILandlordRepository landLordRepository, AccountRepository accountRepository)
    {
        
        _landLordRepository = landLordRepository;
        
        _accountRepository = accountRepository;
    }

    public async Task<bool> CreateNewLandlordAccountAsync(LandLordCreationRequestDto dto)
    {
        var landLords = await _landLordRepository.GetAll();
        
        foreach (var landlord in landLords)
        {
            if (dto.Address == landlord.Account.Address)
            {
                return false;
            }
        }
        var newAcc=  _accountRepository.Add(new Account()
            {
                FirstName = dto.Name,
                LastName = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.TelNumber,
                Address = dto.Address
                
            });
        return true;

    }
}