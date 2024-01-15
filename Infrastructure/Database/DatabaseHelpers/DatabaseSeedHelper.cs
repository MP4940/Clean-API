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
            new Dog { AnimalID = Guid.NewGuid(), Name = "OldG", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "NewG", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Björn", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Patrik", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Alfred", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Stanley", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Rufus", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Ludde", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Felix", Type = "Dog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Peppe", Type = "Dog" }
            ];
        static List<Cat> cats = [
                new Cat { AnimalID = Guid.NewGuid(), Name = "Jack", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Signe", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Rose", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Mittens", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Fred", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Molly", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Charlie", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Oscar", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Tiger", Type = "Cat" },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Simba", Type = "Cat" }
            ];
        static List<Bird> birds = [
                new Bird { AnimalID = Guid.NewGuid(), Name = "Chip", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Paulie", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Polly", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Ace", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Apollo", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Daffy", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Blue", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Skye", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Jay", Type = "Bird" },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Maverick", Type = "Bird" }
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
                    new Animal { AnimalID = x.AnimalID, Name = x.Name, Type = "Dog" }
                );
            }
            foreach (var x in cats)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.AnimalID, Name = x.Name, Type = "Cat" }
                );
            }
            foreach (var x in birds)
            {
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { AnimalID = x.AnimalID, Name = x.Name, Type = "Bird" }
                );
            }
        }
    }
}