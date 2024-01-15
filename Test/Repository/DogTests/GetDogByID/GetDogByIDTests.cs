using Application.Queries.Animals.Dogs.GetDogByID;
using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using Moq;

namespace Test.Repository.DogTests.GetDogByID
{
    [TestFixture]
    internal class GetDogByIDTests
    {
        private Mock<IDogRepository> _dogRepositoryMock;
        private GetDogByIDQueryHandler _getDogByIDQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _getDogByIDQueryHandler = new GetDogByIDQueryHandler(_dogRepositoryMock.Object);
        }

        [Test]
        public async Task GetDogByID_Returns_Correct()
        {
            // Arrange

            List<Dog> dogs =
            [
                new Dog() { DogID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDog1", Type = "Dog" },
                new Dog() { DogID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestDog2", Type = "Dog" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var wantedDog = dogs.Where(dog => dog.DogID == ID).FirstOrDefault()!;

            _dogRepositoryMock.Setup(x => x.GetDogByID(ID)).ReturnsAsync(wantedDog);

            var query = new GetDogByIDQuery(ID);

            // Act
            var result = await _getDogByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DogID, Is.EqualTo(ID));
        }
        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();

            var query = new GetDogByIDQuery(invalidDogId);

            // Act
            var result = await _getDogByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
