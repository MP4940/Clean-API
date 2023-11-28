using Application.Commands.Animals.Birds.UpdateBird;
using Application.Dtos.AnimalsDtos.BirdDto;
using Infrastructure.Database;

namespace Test.AnimalTests.BirdTest.CommandTest
{
    public class UpdateBirdByIDTests
    {
        private MockDatabase _mockDatabase;
        private UpdateBirdByIdCommandHandler _UpdateBirdByIDBirdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _UpdateBirdByIDBirdCommandHandler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task NotNull_And_Values_Updated_Correctly(bool likeToPlay)
        {
            // Arrange
            var birdID = new Guid("12345678-1234-5678-1234-567812345678");
            BirdDto birdDto = new BirdDto { Name = "UpdatedBirdName", CanFly = likeToPlay };

            var queryUpdateBirdByID = new UpdateBirdByIDCommand(birdDto, birdID);

            // Act
            var result = await _UpdateBirdByIDBirdCommandHandler.Handle(queryUpdateBirdByID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(birdDto.Name));
            Assert.That(result.CanFly, Is.EqualTo(birdDto.CanFly));
        }
    }
}