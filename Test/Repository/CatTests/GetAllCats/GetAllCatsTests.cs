using Application.Queries.Animals.Cats.GetAllCats;
using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using Moq;

namespace Test.Repository.CatTests.GetAllCats
{
    [TestFixture]
    internal class GetAllCatsTests
    {
        private Mock<ICatRepository> _catRepositoryMock;
        private GetAllCatsQueryHandler _getAllCatsQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _catRepositoryMock = new Mock<ICatRepository>();
            _getAllCatsQueryHandler = new GetAllCatsQueryHandler(_catRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllCats_Returns_Correct()
        {
            // Arrange
            List<Cat> Cats =
            [
                new Cat() { CatID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestCat1" },
                new Cat() { CatID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestCat2" },
            ];


            _catRepositoryMock.Setup(x => x.GetAllCats()).ReturnsAsync(Cats);

            var query = new GetAllCatsQuery();

            // Act
            var result = await _getAllCatsQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<Cat>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}