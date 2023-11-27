using Domain.Models.Animals.Cats;
using Domain.Models.Animals.Dogs;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> allDogs
        {
            get { return AllDogsFromMockedDatabase; }
            set { AllDogsFromMockedDatabase = value; }
        }

        private static List<Dog> AllDogsFromMockedDatabase = new()
        {
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Stanley"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Rufus"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Updog"
            },
            new Dog
            {
                AnimalID = Guid.NewGuid(), Name = "Fido"
            },
            new Dog
            {
                AnimalID = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"
            },
            new Dog
            {
                AnimalID = new Guid("02345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests2"
            }
        }; 
        
        public List<Cat> allCats
        {
            get { return AllCatsFromMockedDatabase; }
            set { AllCatsFromMockedDatabase = value; }
        }

        private static List<Cat> AllCatsFromMockedDatabase = new()
        {
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Pella", LikesToPlay = true
            },
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Jack", LikesToPlay = true
            },
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Nisse", LikesToPlay = true
            },
            new Cat
            {
                AnimalID = Guid.NewGuid(), Name = "Kattja", LikesToPlay = false
            },
            new Cat
            {
                AnimalID = new Guid("12345678-1234-5678-1234-567812345678"), 
                Name = "TestCatForUnitTests", LikesToPlay = false
            },
            new Cat
            {
                AnimalID = new Guid("02345678-1234-5678-1234-567812345678"), 
                Name = "TestCatForUnitTests2", LikesToPlay = false
            }
        };
    }
}