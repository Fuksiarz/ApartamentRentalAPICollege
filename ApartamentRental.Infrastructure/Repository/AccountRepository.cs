using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using ApartamentRental.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;



public class AccountRepository :IAccountRepository
{
    private readonly MainContext _mainContext;
    public AccountRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Account>> GetAll()
    {
        var accounts = await _mainContext.Account.ToListAsync();

        foreach (var account in accounts)
        {
            await _mainContext.Entry(account).Reference(x => x.Address).LoadAsync();
            
        }

        return accounts;
    }

    public async Task<Account> GetById(int id)
    {
        var account = await _mainContext.Account.SingleOrDefaultAsync(x => x.AddressId == id);
        if (account != null)
        {
            await _mainContext.Entry(account).Reference(x => x.Address).LoadAsync();
            return account;
        }
        
        throw new NotImplementedException();
    }
    

    public async Task Add(Account entity)
    {
        entity.DateOfCreation=DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Account entity)
    {
        var accountToUpdate = await _mainContext.Account.SingleOrDefaultAsync(x => x.AddressId == entity.AddressId);

        if (accountToUpdate == null)
        {
            throw new EntityNotFoundException();

        }

        accountToUpdate.FirstName = entity.FirstName;
        accountToUpdate.LastName = entity.LastName;
        accountToUpdate.Email = entity.Email;
        accountToUpdate.AddressId = entity.AddressId;
        
        accountToUpdate.IsAccountActive = entity.IsAccountActive;
        accountToUpdate.PhoneNumber = entity.PhoneNumber;
        
        
        
    }

    public async Task DeleteById(int id)
    {
        var accountToDelete = await _mainContext.Account.SingleOrDefaultAsync(x => x.AddressId == id);
        if (accountToDelete != null)
        {

            _mainContext.Account.Remove(accountToDelete);
            await _mainContext.SaveChangesAsync();

        }
        throw new EntityNotFoundException();
    }
}