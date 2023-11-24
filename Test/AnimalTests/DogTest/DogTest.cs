using Infrastructure.Database;
using Application.Queries.Animals.Dogs.GetDogByID;
using Application.Commands.Animals.Dogs.DeleteDog;


namespace Test.AnimalTests.DogTest
{
    [TestFixture]
    public class DogTest
    {
        private GetDogByIDQueryHandler _GetDogByIDQueryHandler;
        private DeleteDogByIdCommandHandler _DeleteDogByIDCommandHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetDogByIDQueryHandler = new GetDogByIDQueryHandler(_mockDatabase);
            _DeleteDogByIDCommandHandler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectDog()
        {
            // Arrange
            var dogID = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetDogByIDQuery(dogID);

            // Act
            var result = await _GetDogByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.AnimalID, Is.EqualTo(dogID));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidDogId = Guid.NewGuid();

            var query = new GetDogByIDQuery(invalidDogId);

            // Act
            var result = await _GetDogByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        // WIP Namn
        public async Task Dog_Delete_Test()
        {
            // Arrange
            var dogID = new Guid("02345678-1234-5678-1234-567812345678");

            var query = new DeleteDogByIDCommand(dogID);
            var query2 = new GetDogByIDQuery(dogID);

            // Act
            var result = await _DeleteDogByIDCommandHandler.Handle(query, CancellationToken.None);
            var result2 = await _GetDogByIDQueryHandler.Handle(query2, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsNull(result2);
        }
    }
}