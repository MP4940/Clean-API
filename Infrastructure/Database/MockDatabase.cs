using Domain.Models.Animals.Birds;
using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;
using Domain.Models.Users;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { ID = new Guid("42345678-1234-5678-1234-567812345678"), Username = "admin", Password = "password", Authorized = true, Role = "Admin" },
        };

        public List<Dog> AllDogs
        {
            get { return AllDogsFromMockedDatabase; }
            set { AllDogsFromMockedDatabase = value; }
        }

        private static List<Dog> AllDogsFromMockedDatabase = new()
        {
            new Dog { ID = Guid.NewGuid(), Name = "Stanley" },
            new Dog { ID = Guid.NewGuid(), Name = "Rufus" },
            new Dog { ID = Guid.NewGuid(), Name = "Updog" },
            new Dog { ID = Guid.NewGuid(), Name = "Fido" },
            new Dog { ID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" },
            new Dog { ID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests2" }
        };


        public List<Cat> AllCats
        {
            get { return AllCatsFromMockedDatabase; }
            set { AllCatsFromMockedDatabase = value; }
        }

        private static List<Cat> AllCatsFromMockedDatabase = new()
        {
            new Cat
            { ID = Guid.NewGuid(), Name = "Pella", LikesToPlay = true },
            new Cat { ID = Guid.NewGuid(), Name = "Jack", LikesToPlay = true },
            new Cat { ID = Guid.NewGuid(), Name = "Nisse", LikesToPlay = true },
            new Cat { ID = Guid.NewGuid(), Name = "Kattja", LikesToPlay = false },
            new Cat { ID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests", LikesToPlay = false },
            new Cat { ID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests2", LikesToPlay = false }
        };


        public List<Bird> AllBirds
        {
            get { return AllBirdsFromMockedDatabase; }
            set { AllBirdsFromMockedDatabase = value; }
        }

        private static List<Bird> AllBirdsFromMockedDatabase = new()
        {
            new Bird { ID = Guid.NewGuid(), Name = "Polly", CanFly = true },
            new Bird { ID = Guid.NewGuid(), Name = "Peppe", CanFly = true },
            new Bird { ID = Guid.NewGuid(), Name = "Lars-Åke", CanFly = true },
            new Bird { ID = Guid.NewGuid(), Name = "Harry", CanFly = false },
            new Bird { ID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests", CanFly = false },
            new Bird { ID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests2", CanFly = false }
        };
    }
}