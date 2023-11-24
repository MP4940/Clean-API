using Infrastructure.Database;
using Application.Queries.Animals.Dogs.GetDogByID;


namespace Test.DogTest
{
    [TestFixture]
    public class DogTest
    {
        private GetDogByIDQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetDogByIDQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectDog()
        {
            // Arrange
            var dogID = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetDogByIDQuery(dogID);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

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
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}