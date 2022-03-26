namespace ApartamentRental.Core.Entities;

public class Tenant : BaseEntity
{
    public Apartment Apartament { get; set; }
}