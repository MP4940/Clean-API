using Application.Commands.Animals.Dogs.AddDog;
using Application.Dtos;
using Application.Queries.Animals.Dogs.GetDogByID;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    public class AddDogTest
    {
        private MockDatabase _mockDatabase;
        private GetDogByIDQueryHandler _GetDogByIDQueryHandler;
        private AddDogCommandHandler _AddDogCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetDogByIDQueryHandler = new GetDogByIDQueryHandler(_mockDatabase);
            _AddDogCommandHandler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Dog_Add_Test()
        {
            // Arrange
            var dogID = new Guid("22345678-1234-5678-1234-567812345678");
            DogDto dogDto = new();

            var queryGetDogByID = new GetDogByIDQuery(dogID);
            var queryAddDog = new AddDogCommand(dogDto);

            // Act
            var resultGetByID = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);
            await _AddDogCommandHandler.Handle(queryAddDog, CancellationToken.None);
            var resultGetByID2 = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);

            // Assert
            Assert.IsNull(resultGetByID);
            Assert.NotNull(resultGetByID2);
        }
    }
}