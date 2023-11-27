using Application.Commands.Animals.Dogs.UpdateDog;
using Application.Dtos;
using Application.Queries.Animals.Dogs.GetDogByID;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    public class UpdateDogByID
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
        }
        [Test]
        public async Task Dog_Update_Test()
        {
            // Arrange
            var dogID = new Guid("12345678-1234-5678-1234-567812345678");
            var updatedName = "TestDogForUnitTestsUpdated";
            DogDto dogDto = new();

            var queryGetDogByID = new GetDogByIDQuery(dogID);
            var queryUpdateDogByID = new UpdateDogByIDCommand(dogDto, dogID);

            // Act
            var resultGetByID = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);
            await _UpdateDogByIDDogCommandHandler.Handle(queryUpdateDogByID, CancellationToken.None);
            var resultGetByID2 = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);

            // Assert
            Assert.That(resultGetByID.Name, Is.EqualTo("TestDogForUnitTests"));
            Assert.That(resultGetByID2.Name, Is.EqualTo(updatedName));
        }
    }
}