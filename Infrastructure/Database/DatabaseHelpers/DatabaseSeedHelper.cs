using Domain.Models.Animals.Dogs;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedUsers(modelBuilder);
            // Add more methods for other entities as needed
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { ID = Guid.NewGuid(), Name = "OldG" },
                new Dog { ID = Guid.NewGuid(), Name = "NewG" },
                new Dog { ID = Guid.NewGuid(), Name = "Björn" },
                new Dog { ID = Guid.NewGuid(), Name = "Patrik" },
                new Dog { ID = Guid.NewGuid(), Name = "Alfred" },
                new Dog { ID = new Guid("12345678-1234-5678-1234-567812345671"), Name = "TestDogForUnitTests1" },
                new Dog { ID = new Guid("12345678-1234-5678-1234-567812345672"), Name = "TestDogForUnitTests2" },
                new Dog { ID = new Guid("12345678-1234-5678-1234-567812345673"), Name = "TestDogForUnitTests3" },
                new Dog { ID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDogForUnitTests4" }
            );
        }
        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { ID = Guid.NewGuid(), Username = "admin", Password = "admin", Authorized = true, Role = "admin"}
            );
        }
    }
}