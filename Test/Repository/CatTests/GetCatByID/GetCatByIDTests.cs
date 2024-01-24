using Application.Queries.Animals.Cats.GetCatByID;
using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using Moq;

namespace Test.Repository.CatTests.GetCatByID
{
    [TestFixture]
    internal class GetCatByIDTests
    {
        private Mock<ICatRepository> _catRepositoryMock;
        private GetCatByIDQueryHandler _getCatByIDQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _catRepositoryMock = new Mock<ICatRepository>();
            _getCatByIDQueryHandler = new GetCatByIDQueryHandler(_catRepositoryMock.Object);
        }

        [Test]
        public async Task GetCatByID_Returns_Correct()
        {
            // Arrange

            List<Cat> Cats =
            [
                new Cat() { CatID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestCat1" },
                new Cat() { CatID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestCat2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var wantedCat = Cats.Where(Cat => Cat.CatID == ID).FirstOrDefault()!;

            _catRepositoryMock.Setup(x => x.GetCatByID(ID)).ReturnsAsync(wantedCat);

            var query = new GetCatByIDQuery(ID);

            // Act
            var result = await _getCatByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CatID, Is.EqualTo(ID));
        }
        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidCatId = Guid.NewGuid();

            var query = new GetCatByIDQuery(invalidCatId);

            // Act
            var result = await _getCatByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
