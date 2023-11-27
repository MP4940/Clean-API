using Application.Commands.Animals.Dogs.DeleteDog;
using Application.Queries.Animals.Dogs.GetDogByID;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    [TestFixture]
    public class DeleteDogByIDTest
    {
        private MockDatabase _mockDatabase;
        private GetDogByIDQueryHandler _GetDogByIDQueryHandler;
        private DeleteDogByIdCommandHandler _DeleteDogByIDCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetDogByIDQueryHandler = new GetDogByIDQueryHandler(_mockDatabase);
            _DeleteDogByIDCommandHandler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        // WIP Namn
        public async Task Dog_Delete_Test()
        {
            // Arrange
            var dogID = new Guid("02345678-1234-5678-1234-567812345678");

            var queryDeleteDogByID = new DeleteDogByIDCommand(dogID);
            var queryGetDogByID = new GetDogByIDQuery(dogID);

            // Act
            var resultGetDogByID = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);
            await _DeleteDogByIDCommandHandler.Handle(queryDeleteDogByID, CancellationToken.None);
            var resultGetDogByID2 = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);

            // Assert
            Assert.NotNull(resultGetDogByID);
            Assert.IsNull(resultGetDogByID2);
        }
    }
}