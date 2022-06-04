using ApartamentRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApartamentRental.Infrastructure.Context;

public class MainContext : DbContext
{
    
    public DbSet<Apartment> Apartment { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Image> Image { get; set; }
    public DbSet<Landlord> Landlord { get; set; }
    public DbSet<Tenant> Tenant { get; set; }
    public DbSet<Address> Address { get; set; }

    public MainContext()
    {
        
    }
    public MainContext(DbContextOptions options, DbSet<Apartment> apartment, DbSet<Account> account, DbSet<Image> image, DbSet<Landlord> landlord, DbSet<Tenant> tenant, DbSet<Address> address) : base(options)
    {
        Apartment = apartment;
        Account = account;
        Image = image;
        Landlord = landlord;
        Tenant = tenant;
        Address = address;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.ApartamentRental.db");
        

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>()
            .HasMany(x => x.Images)
            .WithOne(x => x.Apartment)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Landlord>()
            .HasMany(x => x.Apartaments)
            .WithOne(x => x.Landlord)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
    
}