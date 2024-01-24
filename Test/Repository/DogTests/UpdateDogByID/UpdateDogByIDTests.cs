using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using Moq;

namespace Test.Repository.DogTests.UpdateDogByID
{
    [TestFixture]
    internal class UpdateDogByIDTests
    {
        private DogRepository _dogRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _dogRepository = new DogRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Dogs.Update(It.IsAny<Dog>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task Values_Updated_Correctly()
        {
            // Arrange
            List<Dog> dogs =
            [
                new Dog() { DogID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDog1", Breed = "Pudel", Weight = 3 },
                new Dog() { DogID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestDog2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var dogToUpdate = dogs.Where(dog => dog.DogID == ID).FirstOrDefault()!;

            dogToUpdate.Name = "updatedDogname";
            dogToUpdate.Breed = "updatedBreed";
            dogToUpdate.Weight = 66;

            // Act
            var result = await _dogRepository.UpdateDog(dogToUpdate);

            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(dogToUpdate.Name));
            Assert.That(result.Breed, Is.EqualTo(dogToUpdate.Breed));
            Assert.That(result.Weight, Is.EqualTo(dogToUpdate.Weight));
            _mockRealDatabase.Verify(db => db.Dogs.Update(It.IsAny<Dog>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}