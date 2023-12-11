using Application.Queries.Animals.Birds.GetBirdByID;
using Infrastructure.Database;

namespace Test.AnimalTests.BirdTest.QueryTest
{
    [TestFixture]
    public class GetBirdByIDTests
    {
        private GetBirdByIDQueryHandler _GetBirdByIDQueryHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetBirdByIDQueryHandler = new GetBirdByIDQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Returns_Correct_Bird()
        {
            // Arrange
            var birdID = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetBirdByIDQuery(birdID);

            // Act
            var result = await _GetBirdByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.ID, Is.EqualTo(birdID));
        }

        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidBirdId = Guid.NewGuid();

            var query = new GetBirdByIDQuery(invalidBirdId);

            // Act
            var result = await _GetBirdByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}