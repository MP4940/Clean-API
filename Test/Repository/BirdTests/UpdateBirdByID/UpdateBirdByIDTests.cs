using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.Repository.BirdTests.UpdateBirdByID
{
    [TestFixture]
    internal class UpdateBirdByIDTests
    {
        private BirdRepository _birdRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _birdRepository = new BirdRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Birds.Update(It.IsAny<Bird>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }

        [Test]
        public async Task Values_Updated_Correctly()
        {
            // Arrange
            List<Bird> birds =
            [
                new Bird() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestBird1", CanFly = true, Color = "Red" },
                new Bird() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestBird2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var birdToUpdate = birds.Where(bird => bird.AnimalID == ID).FirstOrDefault()!;

            birdToUpdate.Name = "updatedBirdname";
            birdToUpdate.CanFly = false;
            birdToUpdate.Color = "updatedColor";

            // Act
            var result = await _birdRepository.UpdateBird(birdToUpdate);

            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(birdToUpdate.Name));
            Assert.That(result.CanFly, Is.EqualTo(birdToUpdate.CanFly));
            Assert.That(result.Color, Is.EqualTo(birdToUpdate.Color));
            _mockRealDatabase.Verify(db => db.Birds.Update(It.IsAny<Bird>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}