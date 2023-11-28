using Application.Commands.Animals.Cats.UpdateCat;
using Application.Dtos.AnimalsDtos.CatDto;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.CommandTest
{
    public class UpdateCatByID
    {
        private MockDatabase _mockDatabase;
        private UpdateCatByIdCommandHandler _UpdateCatByIDCatCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _UpdateCatByIDCatCommandHandler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task NotNull_And_Values_Updated_Correctly(bool likeToPlay)
        {
            // Arrange
            var catID = new Guid("12345678-1234-5678-1234-567812345678");
            CatDto CatDto = new CatDto { Name = "UpdatedCatName", LikesToPlay = likeToPlay };

            var queryUpdateCatByID = new UpdateCatByIDCommand(CatDto, catID);

            // Act
            var result = await _UpdateCatByIDCatCommandHandler.Handle(queryUpdateCatByID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(CatDto.Name));
            Assert.That(result.LikesToPlay, Is.EqualTo(CatDto.LikesToPlay));
        }
    }
}