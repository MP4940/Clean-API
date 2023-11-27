using Application.Queries.Animals.Cats.GetCatByID;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.QueryTest
{
    [TestFixture]
    public class GetCatByIDTests
    {
        private GetCatByIDQueryHandler _GetCatByIDQueryHandler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetCatByIDQueryHandler = new GetCatByIDQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidId_ReturnsCorrectCat()
        {
            // Arrange
            var CatID = new Guid("12345678-1234-5678-1234-567812345678");

            var query = new GetCatByIDQuery(CatID);

            // Act
            var result = await _GetCatByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.AnimalID, Is.EqualTo(CatID));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();

            var query = new GetCatByIDQuery(invalidCatId);

            // Act
            var result = await _GetCatByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}