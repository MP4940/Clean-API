using Application.Queries.Animals.Birds.GetAllBirds;
using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.Repository.BirdTests.GetAllBirds
{
    [TestFixture]
    internal class GetAllBirdsTests
    {
        private Mock<IBirdRepository> _birdRepositoryMock;
        private GetAllBirdsQueryHandler _getAllBirdsQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _birdRepositoryMock = new Mock<IBirdRepository>();
            _getAllBirdsQueryHandler = new GetAllBirdsQueryHandler(_birdRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllBirds_Returns_Correct()
        {
            // Arrange
            List<Bird> birds =
            [
                new Bird() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestBird1" },
                new Bird() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestBird2" },
            ];


            _birdRepositoryMock.Setup(x => x.GetAllBirds()).ReturnsAsync(birds);

            var query = new GetAllBirdsQuery();

            // Act
            var result = await _getAllBirdsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Bird>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}