using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using Moq;

namespace Test.Repository.DogTests.DeleteDogByID
{
    [TestFixture]
    internal class DeleteDogByIDTests
    {
        private DogRepository _dogRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _dogRepository = new DogRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Dogs.Remove(It.IsAny<Dog>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }

        [Test]
        public async Task Dog_Deleted()
        {
            // Arrange
            List<Dog> dogs =
            [
                new Dog() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDog1" },
                new Dog() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestDog2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var dogToDelete = dogs.Where(dog => dog.AnimalID == ID).FirstOrDefault();

            var result = await _dogRepository.DeleteDog(dogToDelete!);

            Assert.NotNull(result);
            _mockRealDatabase.Verify(db => db.Dogs.Remove(It.IsAny<Dog>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}