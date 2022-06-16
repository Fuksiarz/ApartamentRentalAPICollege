using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApartamentRental.Core.DTO;
using ApartamentRental.Core.Services;
using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Repository;
using FluentAssertions;
using Moq;
using Xunit;

namespace ApartamentRental.Tests;

public class LandLordTests
{
    
    
    
    [Fact]
    public async Task GetTheCheapestApartmentAsync_ShouldReturnNull_WhenApartmentsCollectionIsNull()
    {
        
        var sut = new AccountRepository(Mock.Of<MainContext>());

        var result = await sut.GetAll();
        result.Should().BeNull();
    }
    [Fact]
    public async Task GetTheCheapestApartmentAsync_ShouldReturnTheCheapestApartment()
    {
        var apartments = new Account
        {
            Id = 0,
            DateOfCreation = default,
            DateOfUpdate = default,
            FirstName = "siema",
            LastName = "elo",
            Email = "idk",
            PhoneNumber = "ss",
            IsAccountActive = false,
            AddressId = 0,
            Address = null,
            

        };

        var apartmentRepositoryMock = new Mock<IAccountRepository>();
        apartmentRepositoryMock.Setup(x => x.GetAll());

        var sut = new AccountRepository(Mock.Of<MainContext>());
        var result = await sut.GetAll();
        result.GetEnumerator().Should().Be(1);

    }
    
    
}

