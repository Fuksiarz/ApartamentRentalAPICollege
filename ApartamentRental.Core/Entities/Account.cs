namespace ApartamentRental.Core.Entities;

public class Account : BaseEntity
{
    public string Imie{ get; set; }
    public string Nazwisko{ get; set; } 
    public string Email{ get; set; } 
    public string NumerTelefonu{ get; set; }
    public bool CzyAktywne{ get; set; } 
    
}