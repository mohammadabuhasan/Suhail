﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Suhail.Models;

namespace Suhail.Migrations
{
    [DbContext(typeof(SuhailContext))]
    partial class SuhailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Suhail.Models.Broker", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Bio");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long?>("ParcelID");

                    b.Property<string>("PhoneNumer");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("ParcelID");

                    b.ToTable("Broker");
                });

            modelBuilder.Entity("Suhail.Models.Parcel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlockNumber");

                    b.Property<string>("Description");

                    b.Property<int>("LandUseGroup");

                    b.Property<string>("Neighbourhood");

                    b.Property<decimal>("PriceOfMeter");

                    b.Property<string>("SubdivisionNumber");

                    b.HasKey("ID");

                    b.ToTable("Parcel");
                });

            modelBuilder.Entity("Suhail.Models.Broker", b =>
                {
                    b.HasOne("Suhail.Models.Parcel")
                        .WithMany("OwnerBrokers")
                        .HasForeignKey("ParcelID");
                });
#pragma warning restore 612, 618
        }
    }
}
