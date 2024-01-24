using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.Repository.BirdTests.AddBird
{
    [TestFixture]
    internal class AddBirdTests
    {
        private BirdRepository _birdRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Birds.Add(It.IsAny<Bird>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _birdRepository = new BirdRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task AddBird_Success()
        {
            // Arrange
            var birdToAdd = new Bird() { AnimalID = Guid.NewGuid(), Name = "TestBird3" };

            // Act
            var addedBird = await _birdRepository.AddBird(birdToAdd);

            // Assert
            Assert.NotNull(addedBird);
            Assert.That(addedBird.AnimalID, Is.EqualTo(birdToAdd.AnimalID));
            Assert.That(addedBird.Name, Is.EqualTo(birdToAdd.Name));
            _mockRealDatabase.Verify(db => db.Birds.Add(It.IsAny<Bird>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}