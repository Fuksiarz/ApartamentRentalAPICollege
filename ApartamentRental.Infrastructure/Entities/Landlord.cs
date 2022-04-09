namespace ApartamentRental.Core.Entities;

public class Landlord: BaseEntity
{
    public List<Apartment> Apartaments { get; set; }
    public int AccountId{ get; set; } 
    public Account Account { get; set; } 
    
}