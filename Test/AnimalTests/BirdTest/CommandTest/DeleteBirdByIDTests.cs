using Application.Commands.Animals.Birds.DeleteBird;
using Application.Queries.Animals.Birds.GetBirdByID;
using Infrastructure.Database;

namespace Test.AnimalTests.BirdTest.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIDTests
    {
        private MockDatabase _mockDatabase;
        private GetBirdByIDQueryHandler _GetBirdByIDQueryHandler;
        private DeleteBirdByIdCommandHandler _DeleteBirdByIDCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetBirdByIDQueryHandler = new GetBirdByIDQueryHandler(_mockDatabase);
            _DeleteBirdByIDCommandHandler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Before_Is_Not_Null_After_Is_Null_And_Result_Test()
        {
            // Arrange
            var birdID = new Guid("02345678-1234-5678-1234-567812345678");

            var queryDeleteBirdByID = new DeleteBirdByIDCommand(birdID);
            var queryGetBirdByID = new GetBirdByIDQuery(birdID);

            // Act
            var resultGetBirdByIDBefore = await _GetBirdByIDQueryHandler.Handle(queryGetBirdByID, CancellationToken.None);
            var result = await _DeleteBirdByIDCommandHandler.Handle(queryDeleteBirdByID, CancellationToken.None);
            var resultGetBirdByIDAfter = await _GetBirdByIDQueryHandler.Handle(queryGetBirdByID, CancellationToken.None);

            // Assert
            Assert.NotNull(resultGetBirdByIDBefore);
            Assert.IsNull(resultGetBirdByIDAfter);
            Assert.That(result.AnimalID, Is.EqualTo(birdID));
        }
    }
}