using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartamentRental.Core.Entities;

public class BaseEntity
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DateOfCreation { get; set; }
    public DateTime DateOfUpdate { get; set; } 
    public int I { get; set; }
    
}