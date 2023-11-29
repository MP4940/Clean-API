using Application.Queries.Animals.Birds.GetAllBirds;
using Infrastructure.Database;

namespace Test.AnimalTests.BirdTest.QueryTest
{
    [TestFixture]
    internal class GetAllBirdsTests
    {
        private MockDatabase _mockDatabase;
        private GetAllBirdsQueryHandler _GetAllBirdsQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _GetAllBirdsQueryHandler = new GetAllBirdsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Is_Not_Empty_And_Returns_AllBirds_Correctly()
        {
            // Arrange
            var allBirds = _mockDatabase.AllBirds;
            var query = new GetAllBirdsQuery();

            // Act
            var result = await _GetAllBirdsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(allBirds.Count > 0);
            Assert.That(result, Is.EqualTo(allBirds));
        }
    }
}