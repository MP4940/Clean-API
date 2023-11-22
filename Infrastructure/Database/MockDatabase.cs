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
            }
        };
    }
}
