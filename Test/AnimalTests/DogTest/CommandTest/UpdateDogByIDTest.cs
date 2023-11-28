using Application.Commands.Animals.Dogs.UpdateDog;
using Application.Dtos.AnimalsDtos.DogDto;
using Application.Queries.Animals.Dogs.GetDogByID;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    public class UpdateDogByIDTest
    {
        private MockDatabase _mockDatabase;
        private GetDogByIDQueryHandler _GetDogByIDQueryHandler;
        private UpdateDogByIdCommandHandler _UpdateDogByIDDogCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetDogByIDQueryHandler = new GetDogByIDQueryHandler(_mockDatabase);
            _UpdateDogByIDDogCommandHandler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Dog_Update_Test()
        {
            // Arrange
            var dogID = new Guid("12345678-1234-5678-1234-567812345678");
            DogDto dogDto = new DogDto { Name = "UpdatedDogName" };

            var queryUpdateDogByID = new UpdateDogByIDCommand(dogDto, dogID);

            // Act
            var result = await _UpdateDogByIDDogCommandHandler.Handle(queryUpdateDogByID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
        }
    }
}