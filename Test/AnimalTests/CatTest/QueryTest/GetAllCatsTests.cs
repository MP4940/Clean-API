using Application.Queries.Animals.Cats.GetAllCats;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.QueryTest
{
    [TestFixture]
    internal class GetAllCatsTests
    {
        private MockDatabase _mockDatabase;
        private GetAllCatsQueryHandler _GetAllCatsQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _GetAllCatsQueryHandler = new GetAllCatsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Is_Not_Empty_And_Returns_AllCats_Correctly()
        {
            // Arrange
            var allCats = _mockDatabase.AllCats;
            var query = new GetAllCatsQuery();

            // Act
            var result = await _GetAllCatsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(allCats.Count > 0);
            Assert.That(result, Is.EqualTo(allCats));
        }
    }
}