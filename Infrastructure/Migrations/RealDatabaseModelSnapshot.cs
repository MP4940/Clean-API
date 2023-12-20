﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    partial class RealDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Animals.Dogs.Dog", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            ID = new Guid("c71f9b1d-6602-4722-855e-3e73aa5267d3"),
                            Name = "OldG"
                        },
                        new
                        {
                            ID = new Guid("ad64a3c4-78c8-4e7c-ab21-4644c1a1334b"),
                            Name = "NewG"
                        },
                        new
                        {
                            ID = new Guid("6024561a-29e9-4999-9982-4c70f149eba7"),
                            Name = "Björn"
                        },
                        new
                        {
                            ID = new Guid("da627e2e-7ea8-404f-ade5-fcced2e50b0a"),
                            Name = "Patrik"
                        },
                        new
                        {
                            ID = new Guid("5618fe21-b71b-4c2b-a464-77059a1528d2"),
                            Name = "Alfred"
                        },
                        new
                        {
                            ID = new Guid("12345678-1234-5678-1234-567812345671"),
                            Name = "TestDogForUnitTests1"
                        },
                        new
                        {
                            ID = new Guid("12345678-1234-5678-1234-567812345672"),
                            Name = "TestDogForUnitTests2"
                        },
                        new
                        {
                            ID = new Guid("12345678-1234-5678-1234-567812345673"),
                            Name = "TestDogForUnitTests3"
                        },
                        new
                        {
                            ID = new Guid("12345678-1234-5678-1234-567812345674"),
                            Name = "TestDogForUnitTests4"
                        });
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Authorized")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"),
                            Authorized = true,
                            Password = "admin",
                            Role = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            ID = new Guid("12345678-1234-5678-1234-567812345674"),
                            Authorized = true,
                            Password = "password",
                            Role = "admin",
                            Username = "testUser2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
