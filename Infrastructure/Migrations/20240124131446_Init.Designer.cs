﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20240124131446_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AnimalUsers.AnimalUser", b =>
                {
                    b.Property<Guid>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnimalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Key");

                    b.HasIndex("AnimalID");

                    b.HasIndex("UserID");

                    b.ToTable("AnimalUsers");
                });

            modelBuilder.Entity("Domain.Models.Animals.Animal", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.ToTable("Animals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");

                    b.UseTphMappingStrategy();
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
                            ID = new Guid("c96690ba-bd60-496a-a212-0e6f2b358a61"),
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

            modelBuilder.Entity("Domain.Models.Animals.Birds.Bird", b =>
                {
                    b.HasBaseType("Domain.Models.Animals.Animal");

                    b.Property<bool>("CanFly")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Bird");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("b47d3b4a-720c-4f2b-99dd-5f19c6c1b756"),
                            Name = "Chip",
                            CanFly = false,
                            Color = "Red"
                        },
                        new
                        {
                            AnimalID = new Guid("ce762ec5-93d6-48b1-8e17-fceef9a3cf89"),
                            Name = "Paulie",
                            CanFly = true,
                            Color = "Blue"
                        },
                        new
                        {
                            AnimalID = new Guid("6361d7d6-1fe3-4e3a-96a1-15916264d498"),
                            Name = "Polly",
                            CanFly = true,
                            Color = "Orange"
                        },
                        new
                        {
                            AnimalID = new Guid("98f350c8-6c1c-48d9-8092-eea48f2bded0"),
                            Name = "Ace",
                            CanFly = false,
                            Color = "Red"
                        },
                        new
                        {
                            AnimalID = new Guid("9a6cf3fe-cb59-4ecb-bf77-cff89de244e7"),
                            Name = "Apollo",
                            CanFly = false,
                            Color = "Green"
                        },
                        new
                        {
                            AnimalID = new Guid("66582388-955a-474b-a1d8-8c88b234f9c3"),
                            Name = "Daffy",
                            CanFly = true,
                            Color = "Green"
                        },
                        new
                        {
                            AnimalID = new Guid("e65d1f79-4cce-4d7e-afc9-c3e1e3fdfdc9"),
                            Name = "Blue",
                            CanFly = true,
                            Color = "Purple"
                        },
                        new
                        {
                            AnimalID = new Guid("37cf4fe4-5971-418f-86de-e9041bb3fd38"),
                            Name = "Skye",
                            CanFly = false,
                            Color = "Yellow"
                        },
                        new
                        {
                            AnimalID = new Guid("f6583782-ee82-4700-b494-0b7388b2f53e"),
                            Name = "Jay",
                            CanFly = true,
                            Color = "Purple"
                        },
                        new
                        {
                            AnimalID = new Guid("80e652c7-5520-4cc6-a34c-0bb48e3d3f0e"),
                            Name = "Maverick",
                            CanFly = true,
                            Color = "Yellow"
                        });
                });

            modelBuilder.Entity("Domain.Models.Animals.Cats.Cat", b =>
                {
                    b.HasBaseType("Domain.Models.Animals.Animal");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("bit");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cat");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("b910c506-484b-4b8b-ab9d-c9c5b032a2f7"),
                            Name = "Jack",
                            Breed = "Siames",
                            LikesToPlay = true,
                            Weight = 3
                        },
                        new
                        {
                            AnimalID = new Guid("c0f78184-8293-4186-afc7-c5c92d8b08df"),
                            Name = "Signe",
                            Breed = "Ragdoll",
                            LikesToPlay = false,
                            Weight = 4
                        },
                        new
                        {
                            AnimalID = new Guid("f4f319e2-67b2-4053-a99d-6b74a8118e25"),
                            Name = "Rose",
                            Breed = "Bengal",
                            LikesToPlay = false,
                            Weight = 6
                        },
                        new
                        {
                            AnimalID = new Guid("c9c3663d-b2b6-43ba-a423-064c63bc45a5"),
                            Name = "Mittens",
                            Breed = "Burma",
                            LikesToPlay = true,
                            Weight = 5
                        },
                        new
                        {
                            AnimalID = new Guid("a42f3ae3-5c38-4610-8fb8-1d89c5c4fdaf"),
                            Name = "Fred",
                            Breed = "Brittiskt korthår",
                            LikesToPlay = true,
                            Weight = 4
                        },
                        new
                        {
                            AnimalID = new Guid("bfa164e2-b1b0-4707-886f-fb8f7c815bfa"),
                            Name = "Molly",
                            Breed = "Ragdoll",
                            LikesToPlay = false,
                            Weight = 6
                        },
                        new
                        {
                            AnimalID = new Guid("3f2b76db-9e56-4d20-a891-afc836cd4798"),
                            Name = "Charlie",
                            Breed = "Perser",
                            LikesToPlay = true,
                            Weight = 3
                        },
                        new
                        {
                            AnimalID = new Guid("7b0c9162-bd4a-4197-9c8d-73a6105e330c"),
                            Name = "Oscar",
                            Breed = "Burma",
                            LikesToPlay = true,
                            Weight = 4
                        },
                        new
                        {
                            AnimalID = new Guid("73f2198c-c8bd-434d-b2c3-cc0b95dbc701"),
                            Name = "Tiger",
                            Breed = "Perser",
                            LikesToPlay = false,
                            Weight = 5
                        },
                        new
                        {
                            AnimalID = new Guid("197ef754-ba01-4131-a489-3e10f017a97e"),
                            Name = "Simba",
                            Breed = "Bengal",
                            LikesToPlay = true,
                            Weight = 6
                        });
                });

            modelBuilder.Entity("Domain.Models.Animals.Dogs.Dog", b =>
                {
                    b.HasBaseType("Domain.Models.Animals.Animal");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.ToTable("Animals", t =>
                        {
                            t.Property("Breed")
                                .HasColumnName("Dog_Breed");

                            t.Property("Weight")
                                .HasColumnName("Dog_Weight");
                        });

                    b.HasDiscriminator().HasValue("Dog");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("5b8865c8-73db-48f8-bd6b-06ff2bc129d0"),
                            Name = "OldG",
                            Breed = "Labrador",
                            Weight = 10
                        },
                        new
                        {
                            AnimalID = new Guid("22977236-9193-44a4-977e-6b3d1a2b6851"),
                            Name = "NewG",
                            Breed = "Bulldog",
                            Weight = 4
                        },
                        new
                        {
                            AnimalID = new Guid("e1aa5de6-cd87-40ed-885c-5719da9a4582"),
                            Name = "Björn",
                            Breed = "Schäfer",
                            Weight = 12
                        },
                        new
                        {
                            AnimalID = new Guid("d45f169d-e7a4-4894-9feb-aa27d0600fd8"),
                            Name = "Patrik",
                            Breed = "Golden retriever",
                            Weight = 13
                        },
                        new
                        {
                            AnimalID = new Guid("832a11d5-cf72-43c6-b081-ebe87119d4e1"),
                            Name = "Alfred",
                            Breed = "Pudel",
                            Weight = 6
                        },
                        new
                        {
                            AnimalID = new Guid("646e9bd3-eda6-4f27-8ab8-1bd1593c0b8a"),
                            Name = "Stanley",
                            Breed = "Labrador",
                            Weight = 6
                        },
                        new
                        {
                            AnimalID = new Guid("9bba7692-c200-4fb5-a091-04252cb26a29"),
                            Name = "Rufus",
                            Breed = "Rottweiler",
                            Weight = 8
                        },
                        new
                        {
                            AnimalID = new Guid("b19896b8-9740-4514-93a9-fafffed45911"),
                            Name = "Ludde",
                            Breed = "Boxer",
                            Weight = 9
                        },
                        new
                        {
                            AnimalID = new Guid("eae0fe3e-ea23-4a76-893a-cb246ccaf508"),
                            Name = "Felix",
                            Breed = "Labrador",
                            Weight = 12
                        },
                        new
                        {
                            AnimalID = new Guid("d87deba0-4d76-4563-90c4-6c0ca3501cab"),
                            Name = "Peppe",
                            Breed = "Boxer",
                            Weight = 8
                        });
                });

            modelBuilder.Entity("Domain.Models.AnimalUsers.AnimalUser", b =>
                {
                    b.HasOne("Domain.Models.Animals.Animal", "Animal")
                        .WithMany("AnimalUsers")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Users.User", "User")
                        .WithMany("AnimalUsers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Animals.Animal", b =>
                {
                    b.Navigation("AnimalUsers");
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Navigation("AnimalUsers");
                });
#pragma warning restore 612, 618
        }
    }
}