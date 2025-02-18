﻿// <auto-generated />
using System;
using ApartamentRental.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApartamentRental.Infrastructure.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20220614164224_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AparmentNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsElevator")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LandlordId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("LandlordId");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("Apartment");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Landlord");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Account", b =>
                {
                    b.HasOne("ApartamentRental.Infrastructure.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Apartment", b =>
                {
                    b.HasOne("ApartamentRental.Infrastructure.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartamentRental.Infrastructure.Entities.Landlord", "Landlord")
                        .WithMany("Apartaments")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApartamentRental.Infrastructure.Entities.Tenant", "Tenant")
                        .WithOne("Apartment")
                        .HasForeignKey("ApartamentRental.Infrastructure.Entities.Apartment", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Landlord");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Image", b =>
                {
                    b.HasOne("ApartamentRental.Infrastructure.Entities.Apartment", "Apartment")
                        .WithMany("Images")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Landlord", b =>
                {
                    b.HasOne("ApartamentRental.Infrastructure.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Tenant", b =>
                {
                    b.HasOne("ApartamentRental.Infrastructure.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Apartment", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Landlord", b =>
                {
                    b.Navigation("Apartaments");
                });

            modelBuilder.Entity("ApartamentRental.Infrastructure.Entities.Tenant", b =>
                {
                    b.Navigation("Apartment");
                });
#pragma warning restore 612, 618
        }
    }
}
