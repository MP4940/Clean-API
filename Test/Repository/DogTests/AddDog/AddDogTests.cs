using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Dogs;
using Moq;

namespace Test.Repository.DogTests.AddDog
{
    [TestFixture]
    internal class AddDogTests
    {
        private DogRepository _dogRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Dogs.Add(It.IsAny<Dog>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _dogRepository = new DogRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task AddDog_Success()
        {
            // Arrange
            var dogToAdd = new Dog() { DogID = Guid.NewGuid(), Name = "TestDog3" };

            // Act
            var addedDog = await _dogRepository.AddDog(dogToAdd);

            // Assert
            Assert.NotNull(addedDog);
            Assert.That(addedDog.DogID, Is.EqualTo(dogToAdd.DogID));
            Assert.That(addedDog.Name, Is.EqualTo(dogToAdd.Name));
            _mockRealDatabase.Verify(db => db.Dogs.Add(It.IsAny<Dog>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}