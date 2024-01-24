using Application.Queries.Animals.Birds.GetBirdByID;
using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using Moq;

namespace Test.Repository.BirdTests.GetBirdByID
{
    [TestFixture]
    internal class GetBirdByIDTests
    {
        private Mock<IBirdRepository> _birdRepositoryMock;
        private GetBirdByIDQueryHandler _getBirdByIDQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _birdRepositoryMock = new Mock<IBirdRepository>();
            _getBirdByIDQueryHandler = new GetBirdByIDQueryHandler(_birdRepositoryMock.Object);
        }

        [Test]
        public async Task GetBirdByID_Returns_Correct()
        {
            // Arrange

            List<Bird> birds =
            [
                new Bird() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestBird1" },
                new Bird() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestBird2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var wantedBird = birds.Where(bird => bird.AnimalID == ID).FirstOrDefault()!;

            _birdRepositoryMock.Setup(x => x.GetBirdByID(ID)).ReturnsAsync(wantedBird);

            var query = new GetBirdByIDQuery(ID);

            // Act
            var result = await _getBirdByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.AnimalID, Is.EqualTo(ID));
        }
        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidBirdID = Guid.NewGuid();

            var query = new GetBirdByIDQuery(invalidBirdID);

            // Act
            var result = await _getBirdByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
