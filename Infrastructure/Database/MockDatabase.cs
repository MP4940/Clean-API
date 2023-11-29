using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;
using Domain.Models.Animals.Birds;
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
            new User { Id = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Tobias", Password = "123password", Authorized = true, Role = "Admin" },
            new User { Id = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "NotAnAdmin", Password = "123password", Authorized = false, Role = "User"}
        };

        public List<Dog> AllDogs
        {
            get { return AllDogsFromMockedDatabase; }
            set { AllDogsFromMockedDatabase = value; }
        }

        private static List<Dog> AllDogsFromMockedDatabase = new()
        {
            new Dog { AnimalID = Guid.NewGuid(), Name = "Stanley" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Rufus" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Updog" },
            new Dog { AnimalID = Guid.NewGuid(), Name = "Fido" },
            new Dog { AnimalID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" },
            new Dog { AnimalID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests2" }
        };


        public List<Cat> AllCats
        {
            get { return AllCatsFromMockedDatabase; }
            set { AllCatsFromMockedDatabase = value; }
        }

        private static List<Cat> AllCatsFromMockedDatabase = new()
        {
            new Cat
            { AnimalID = Guid.NewGuid(), Name = "Pella", LikesToPlay = true },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Jack", LikesToPlay = true },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Nisse", LikesToPlay = true },
            new Cat { AnimalID = Guid.NewGuid(), Name = "Kattja", LikesToPlay = false },
            new Cat { AnimalID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests", LikesToPlay = false },
            new Cat { AnimalID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests2", LikesToPlay = false }
        };


        public List<Bird> AllBirds
        {
            get { return AllBirdsFromMockedDatabase; }
            set { AllBirdsFromMockedDatabase = value; }
        }

        private static List<Bird> AllBirdsFromMockedDatabase = new()
        {
            new Bird { AnimalID = Guid.NewGuid(), Name = "Polly", CanFly = true },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Peppe", CanFly = true },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Lars-Åke", CanFly = true },
            new Bird { AnimalID = Guid.NewGuid(), Name = "Harry", CanFly = false },
            new Bird { AnimalID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests", CanFly = false },
            new Bird { AnimalID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests2", CanFly = false }
        };
    }
}