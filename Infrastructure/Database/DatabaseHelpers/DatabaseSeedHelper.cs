using Domain.Models.Animals;
using Domain.Models.Animals.Birds;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        static List<Dog> dogs = [
            new Dog { AnimalID = Guid.NewGuid(), Name = "OldG", Weight = 10, Breed = "Labrador" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "NewG", Weight = 4, Breed = "Bulldog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Björn", Weight = 12, Breed = "Schäfer" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Patrik", Weight = 13, Breed = "Golden retriever" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Alfred", Weight = 6, Breed = "Pudel" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Stanley", Weight = 6, Breed = "Labrador" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Rufus", Weight = 8, Breed = "Rottweiler" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Ludde", Weight = 9, Breed = "Boxer" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Felix", Weight = 12, Breed = "Labrador" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Peppe", Weight = 8, Breed = "Boxer" }
        ];
        static List<Cat> cats = [
            new Cat { AnimalID = Guid.NewGuid(), Name = "Jack", LikesToPlay = true, Weight = 3, Breed = "Siames" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Signe", LikesToPlay = false, Weight = 4, Breed = "Ragdoll" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Rose", LikesToPlay = false, Weight = 6, Breed = "Bengal" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Mittens", LikesToPlay = true, Weight = 5, Breed = "Burma" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Fred", LikesToPlay = true, Weight = 4, Breed = "Brittiskt korthår" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Molly", LikesToPlay = false, Weight = 6, Breed = "Ragdoll" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Charlie", LikesToPlay = true, Weight = 3, Breed = "Perser" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Oscar", LikesToPlay = true, Weight = 4, Breed = "Burma" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Tiger", LikesToPlay = false, Weight = 5, Breed = "Perser" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Simba", LikesToPlay = true, Weight = 6, Breed = "Bengal" }
        ];
        static List<Bird> birds = [
            new Bird { AnimalID = Guid.NewGuid(), Name = "Chip", CanFly = false, Color = "Red" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Paulie", CanFly = true, Color = "Blue" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Polly", CanFly = true, Color = "Orange" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Ace", CanFly = false, Color = "Red" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Apollo", CanFly = false, Color = "Green" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Daffy", CanFly = true, Color = "Green" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Blue", CanFly = true, Color = "Purple" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Skye", CanFly = false, Color = "Yellow" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Jay", CanFly = true, Color = "Purple" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Maverick", CanFly = true, Color = "Yellow" }
        ];
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            SeedCats(modelBuilder);
            SeedBirds(modelBuilder);
            //SeedAnimals(modelBuilder);
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                dogs
            );
        }
        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                cats
                );
        }

        private static void SeedBirds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bird>().HasData(
                birds
                );
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { ID = Guid.NewGuid(), Username = "admin", Password = "admin", Authorized = true, Role = "admin" },
                new User { ID = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" }
            );
        }

        private static void SeedAnimals(ModelBuilder modelBuilder)
        {
            foreach (var x in dogs)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.AnimalID, Name = x.Name }
                );
            }
            foreach (var x in cats)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.AnimalID, Name = x.Name }
                );
            }
            foreach (var x in birds)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.AnimalID, Name = x.Name }
                );
            }
        }
    }
}