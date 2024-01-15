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
            new Dog { ID = Guid.NewGuid(), Name = "OldG" },
            new Dog { ID = Guid.NewGuid(), Name = "NewG" },
            new Dog { ID = Guid.NewGuid(), Name = "Björn" },
            new Dog { ID = Guid.NewGuid(), Name = "Patrik" },
            new Dog { ID = Guid.NewGuid(), Name = "Alfred" },
            new Dog { ID = Guid.NewGuid(), Name = "Stanley" },
            new Dog { ID = Guid.NewGuid(), Name = "Rufus" },
            new Dog { ID = Guid.NewGuid(), Name = "Ludde" },
            new Dog { ID = Guid.NewGuid(), Name = "Felix" },
            new Dog { ID = Guid.NewGuid(), Name = "Peppe" }
            ];
        static List<Cat> cats = [
                new Cat { ID = Guid.NewGuid(), Name = "Jack" },
            new Cat { ID = Guid.NewGuid(), Name = "Signe" },
            new Cat { ID = Guid.NewGuid(), Name = "Rose" },
            new Cat { ID = Guid.NewGuid(), Name = "Mittens" },
            new Cat { ID = Guid.NewGuid(), Name = "Fred" },
            new Cat { ID = Guid.NewGuid(), Name = "Molly" },
            new Cat { ID = Guid.NewGuid(), Name = "Charlie" },
            new Cat { ID = Guid.NewGuid(), Name = "Oscar" },
            new Cat { ID = Guid.NewGuid(), Name = "Tiger" },
            new Cat { ID = Guid.NewGuid(), Name = "Simba" }
            ];
        static List<Bird> birds = [
                new Bird { ID = Guid.NewGuid(), Name = "Chip" },
            new Bird { ID = Guid.NewGuid(), Name = "Paulie" },
            new Bird { ID = Guid.NewGuid(), Name = "Polly" },
            new Bird { ID = Guid.NewGuid(), Name = "Ace" },
            new Bird { ID = Guid.NewGuid(), Name = "Apollo" },
            new Bird { ID = Guid.NewGuid(), Name = "Daffy" },
            new Bird { ID = Guid.NewGuid(), Name = "Blue" },
            new Bird { ID = Guid.NewGuid(), Name = "Skye" },
            new Bird { ID = Guid.NewGuid(), Name = "Jay" },
            new Bird { ID = Guid.NewGuid(), Name = "Maverick" }
            ];
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            SeedCats(modelBuilder);
            SeedBirds(modelBuilder);
            SeedAnimals(modelBuilder);
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
                    new Animal { AnimalID = x.ID, Name = x.Name, Type = "Dog" }
                );
            }
            foreach (var x in cats)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.ID, Name = x.Name, Type = "Cat" }
                );
            }
            foreach (var x in birds)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.ID, Name = x.Name, Type = "Bird" }
                );
            }
        }
    }
}