using Application.Commands.Animals.Dogs.DeleteDog;
using Application.Queries.Animals.Dogs.GetDogByID;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    [TestFixture]
    public class DeleteDogByIDTests
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
        public async Task Before_Is_Not_Null_After_Is_Null_And_Result_Test()
        {
            // Arrange
            var dogID = new Guid("02345678-1234-5678-1234-567812345678");

            var queryDeleteDogByID = new DeleteDogByIDCommand(dogID);
            var queryGetDogByID = new GetDogByIDQuery(dogID);

            // Act
            var resultGetDogByIDBefore = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);
            var result = await _DeleteDogByIDCommandHandler.Handle(queryDeleteDogByID, CancellationToken.None);
            var resultGetDogByIDAfter = await _GetDogByIDQueryHandler.Handle(queryGetDogByID, CancellationToken.None);

            // Assert
            Assert.NotNull(resultGetDogByIDBefore);
            Assert.IsNull(resultGetDogByIDAfter);
            Assert.That(result.AnimalID, Is.EqualTo(dogID));
        }
    }
}