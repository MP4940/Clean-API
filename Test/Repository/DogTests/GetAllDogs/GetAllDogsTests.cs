using Application.Queries.Animals.Dogs.GetAllDogs;
using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using Moq;

namespace Test.Repository.DogTests.GetAllDogs
{
    [TestFixture]
    internal class GetAllDogsTests
    {
        private Mock<IDogRepository> _dogRepositoryMock;
        private GetAllDogsQueryHandler _getAllDogsQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _dogRepositoryMock = new Mock<IDogRepository>();
            _getAllDogsQueryHandler = new GetAllDogsQueryHandler(_dogRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllDogs_Returns_Correct()
        {
            // Arrange
            List<Dog> dogs =
            [
                new Dog() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDog1" },
                new Dog() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestDog2" },
            ];


            _dogRepositoryMock.Setup(x => x.GetAllDogs()).ReturnsAsync(dogs);

            var query = new GetAllDogsQuery();

            // Act
            var result = await _getAllDogsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Dog>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}