using Application.Queries.Animals.Dogs.GetAllDogs;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.QueryTest
{
    [TestFixture]
    internal class GetAllDogsTests
    {
        private GetAllDogsQueryHandler _GetAllDogsQueryHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetAllDogsQueryHandler = new GetAllDogsQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task All_Dogs_Test()
        {
            // Arrange
            var allDogs = _mockDatabase.allDogs;
            var query = new GetAllDogsQuery();

            // Act
            var result = await _GetAllDogsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(allDogs));
        }
    }
}
