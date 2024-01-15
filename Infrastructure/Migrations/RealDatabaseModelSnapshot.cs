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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalID = new Guid("51ab4d02-67ec-4dd7-9cc6-48776fe085ec"),
                            Name = "OldG",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("0b301788-d64e-4594-a30e-922b5a4fa6ce"),
                            Name = "NewG",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("2bdc570f-2dfc-4030-a7a0-aa941c8f7d8a"),
                            Name = "Björn",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("93b9ce5b-702a-48ba-94b0-28e7be4238c0"),
                            Name = "Patrik",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("0ad2c029-7091-45b8-a1ae-ef524ad5dc75"),
                            Name = "Alfred",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("18443ea7-ad72-49e5-98a2-7283f33edca7"),
                            Name = "Stanley",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("6f2a781a-00cf-4b96-984e-417de0ff32ac"),
                            Name = "Rufus",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("d85d2592-1bac-4ec6-98ed-2808b178a76d"),
                            Name = "Ludde",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("07b05f70-b4d3-42f8-a08a-d159f001f69f"),
                            Name = "Felix",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("252c161c-d683-4834-b8a4-c1c8518e5ae8"),
                            Name = "Peppe",
                            Type = "Dog"
                        },
                        new
                        {
                            AnimalID = new Guid("9863866a-5fa8-4da0-a658-cd8d8b3e13d0"),
                            Name = "Jack",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("6dffb82f-413b-4de0-a38f-4091c6ec85a8"),
                            Name = "Signe",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("a1df3dd3-eb8d-46c6-a975-02f2fce5ab67"),
                            Name = "Rose",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("e5441e24-19ff-41b0-bb3a-46185e28e797"),
                            Name = "Mittens",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("02504f95-6003-46ee-aac2-3d6d2548d17e"),
                            Name = "Fred",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("03503de9-8804-49dd-9d4b-ea4f999c7fc3"),
                            Name = "Molly",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("031dc261-1db9-4d5f-a41e-fa110dd615ca"),
                            Name = "Charlie",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("47161f1d-208b-4dd9-b940-9610b3db0388"),
                            Name = "Oscar",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("2e0e770a-664b-4e27-b5b8-2887efa9776e"),
                            Name = "Tiger",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("a35114a7-780e-4125-a867-5e7aed7c3862"),
                            Name = "Simba",
                            Type = "Cat"
                        },
                        new
                        {
                            AnimalID = new Guid("db39b87a-071a-4c19-9bb2-032182f83806"),
                            Name = "Chip",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("236587dd-d212-4652-a488-4de8ed28cd01"),
                            Name = "Paulie",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("a87ffa33-8f03-44d4-9bf5-b30457ef9b8e"),
                            Name = "Polly",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("36aacbc7-9116-45c5-955c-1c136ec1c907"),
                            Name = "Ace",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("7a252ddc-fc86-454b-823c-2f66514b96cc"),
                            Name = "Apollo",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("1b66dd99-df6e-48b5-b758-c34986bfbacf"),
                            Name = "Daffy",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("68b98483-ce21-447c-8e35-86bb5ec36b9a"),
                            Name = "Blue",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("1ec80990-e04c-43de-9305-1f7f24d651a0"),
                            Name = "Skye",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("1edd022a-3bee-48f3-ba3c-76d96fcb9139"),
                            Name = "Jay",
                            Type = "Bird"
                        },
                        new
                        {
                            AnimalID = new Guid("0355ffbe-eee3-49de-a33c-3fa17762e454"),
                            Name = "Maverick",
                            Type = "Bird"
                        });
                });

            modelBuilder.Entity("Domain.Models.Animals.Birds.Bird", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanFly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.HasIndex("AnimalID");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            ID = new Guid("db39b87a-071a-4c19-9bb2-032182f83806"),
                            CanFly = false,
                            Name = "Chip"
                        },
                        new
                        {
                            ID = new Guid("236587dd-d212-4652-a488-4de8ed28cd01"),
                            CanFly = false,
                            Name = "Paulie"
                        },
                        new
                        {
                            ID = new Guid("a87ffa33-8f03-44d4-9bf5-b30457ef9b8e"),
                            CanFly = false,
                            Name = "Polly"
                        },
                        new
                        {
                            ID = new Guid("36aacbc7-9116-45c5-955c-1c136ec1c907"),
                            CanFly = false,
                            Name = "Ace"
                        },
                        new
                        {
                            ID = new Guid("7a252ddc-fc86-454b-823c-2f66514b96cc"),
                            CanFly = false,
                            Name = "Apollo"
                        },
                        new
                        {
                            ID = new Guid("1b66dd99-df6e-48b5-b758-c34986bfbacf"),
                            CanFly = false,
                            Name = "Daffy"
                        },
                        new
                        {
                            ID = new Guid("68b98483-ce21-447c-8e35-86bb5ec36b9a"),
                            CanFly = false,
                            Name = "Blue"
                        },
                        new
                        {
                            ID = new Guid("1ec80990-e04c-43de-9305-1f7f24d651a0"),
                            CanFly = false,
                            Name = "Skye"
                        },
                        new
                        {
                            ID = new Guid("1edd022a-3bee-48f3-ba3c-76d96fcb9139"),
                            CanFly = false,
                            Name = "Jay"
                        },
                        new
                        {
                            ID = new Guid("0355ffbe-eee3-49de-a33c-3fa17762e454"),
                            CanFly = false,
                            Name = "Maverick"
                        });
                });

            modelBuilder.Entity("Domain.Models.Animals.Cats.Cat", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("LikesToPlay")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.HasIndex("AnimalID");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            ID = new Guid("9863866a-5fa8-4da0-a658-cd8d8b3e13d0"),
                            LikesToPlay = false,
                            Name = "Jack"
                        },
                        new
                        {
                            ID = new Guid("6dffb82f-413b-4de0-a38f-4091c6ec85a8"),
                            LikesToPlay = false,
                            Name = "Signe"
                        },
                        new
                        {
                            ID = new Guid("a1df3dd3-eb8d-46c6-a975-02f2fce5ab67"),
                            LikesToPlay = false,
                            Name = "Rose"
                        },
                        new
                        {
                            ID = new Guid("e5441e24-19ff-41b0-bb3a-46185e28e797"),
                            LikesToPlay = false,
                            Name = "Mittens"
                        },
                        new
                        {
                            ID = new Guid("02504f95-6003-46ee-aac2-3d6d2548d17e"),
                            LikesToPlay = false,
                            Name = "Fred"
                        },
                        new
                        {
                            ID = new Guid("03503de9-8804-49dd-9d4b-ea4f999c7fc3"),
                            LikesToPlay = false,
                            Name = "Molly"
                        },
                        new
                        {
                            ID = new Guid("031dc261-1db9-4d5f-a41e-fa110dd615ca"),
                            LikesToPlay = false,
                            Name = "Charlie"
                        },
                        new
                        {
                            ID = new Guid("47161f1d-208b-4dd9-b940-9610b3db0388"),
                            LikesToPlay = false,
                            Name = "Oscar"
                        },
                        new
                        {
                            ID = new Guid("2e0e770a-664b-4e27-b5b8-2887efa9776e"),
                            LikesToPlay = false,
                            Name = "Tiger"
                        },
                        new
                        {
                            ID = new Guid("a35114a7-780e-4125-a867-5e7aed7c3862"),
                            LikesToPlay = false,
                            Name = "Simba"
                        });
                });

            modelBuilder.Entity("Domain.Models.Animals.Dogs.Dog", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalID");

                    b.HasIndex("AnimalID");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            ID = new Guid("51ab4d02-67ec-4dd7-9cc6-48776fe085ec"),
                            Name = "OldG"
                        },
                        new
                        {
                            ID = new Guid("0b301788-d64e-4594-a30e-922b5a4fa6ce"),
                            Name = "NewG"
                        },
                        new
                        {
                            ID = new Guid("2bdc570f-2dfc-4030-a7a0-aa941c8f7d8a"),
                            Name = "Björn"
                        },
                        new
                        {
                            ID = new Guid("93b9ce5b-702a-48ba-94b0-28e7be4238c0"),
                            Name = "Patrik"
                        },
                        new
                        {
                            ID = new Guid("0ad2c029-7091-45b8-a1ae-ef524ad5dc75"),
                            Name = "Alfred"
                        },
                        new
                        {
                            ID = new Guid("18443ea7-ad72-49e5-98a2-7283f33edca7"),
                            Name = "Stanley"
                        },
                        new
                        {
                            ID = new Guid("6f2a781a-00cf-4b96-984e-417de0ff32ac"),
                            Name = "Rufus"
                        },
                        new
                        {
                            ID = new Guid("d85d2592-1bac-4ec6-98ed-2808b178a76d"),
                            Name = "Ludde"
                        },
                        new
                        {
                            ID = new Guid("07b05f70-b4d3-42f8-a08a-d159f001f69f"),
                            Name = "Felix"
                        },
                        new
                        {
                            ID = new Guid("252c161c-d683-4834-b8a4-c1c8518e5ae8"),
                            Name = "Peppe"
                        });
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Property<Guid>("AnimalID")
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

                    b.HasKey("AnimalID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = new Guid("86c0791c-886e-4535-a6a6-d2621613a907"),
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

            modelBuilder.Entity("Domain.Models.Animals.Birds.Bird", b =>
                {
                    b.HasOne("Domain.Models.Animals.Animal", null)
                        .WithMany("Birds")
                        .HasForeignKey("AnimalID");
                });

            modelBuilder.Entity("Domain.Models.Animals.Cats.Cat", b =>
                {
                    b.HasOne("Domain.Models.Animals.Animal", null)
                        .WithMany("Cats")
                        .HasForeignKey("AnimalID");
                });

            modelBuilder.Entity("Domain.Models.Animals.Dogs.Dog", b =>
                {
                    b.HasOne("Domain.Models.Animals.Animal", null)
                        .WithMany("Dogs")
                        .HasForeignKey("AnimalID");
                });

            modelBuilder.Entity("Domain.Models.Animals.Animal", b =>
                {
                    b.Navigation("AnimalUsers");

                    b.Navigation("Birds");

                    b.Navigation("Cats");

                    b.Navigation("Dogs");
                });

            modelBuilder.Entity("Domain.Models.Users.User", b =>
                {
                    b.Navigation("AnimalUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
