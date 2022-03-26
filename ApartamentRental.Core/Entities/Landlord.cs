namespace ApartamentRental.Core.Entities;

public class Landlord: BaseEntity
{
    public List<Apartment> Apartamenty { get; set; }
}