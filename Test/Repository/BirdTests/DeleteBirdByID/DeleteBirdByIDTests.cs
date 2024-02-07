using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.Repository.BirdTests.DeleteBirdByID
{
    [TestFixture]
    internal class DeleteBirdByIDTests
    {
        private BirdRepository _birdRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _birdRepository = new BirdRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Birds.Remove(It.IsAny<Bird>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }

        [Test]
        public async Task Bird_Deleted()
        {
            // Arrange
            List<Bird> birds =
            [
                new Bird() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestBird1" },
                new Bird() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestBird2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var BirdToDelete = birds.Where(bird => bird.AnimalID == ID).FirstOrDefault();

            var result = await _birdRepository.DeleteBird(BirdToDelete!);

            Assert.NotNull(result);
            _mockRealDatabase.Verify(db => db.Birds.Remove(It.IsAny<Bird>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}