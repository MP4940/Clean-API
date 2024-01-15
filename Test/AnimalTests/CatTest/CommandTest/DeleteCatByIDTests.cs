using Application.Commands.Animals.Cats.DeleteCat;
using Application.Queries.Animals.Cats.GetCatByID;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.CommandTest
{
    //[TestFixture]
    //public class DeleteCatByIDTests
    //{
    //    private MockDatabase _mockDatabase;
    //    private GetCatByIDQueryHandler _GetCatByIDQueryHandler;
    //    private DeleteCatByIdCommandHandler _DeleteCatByIDCommandHandler;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        // Initialize the handler and mock database before each test
    //        _mockDatabase = new MockDatabase();
    //        _GetCatByIDQueryHandler = new GetCatByIDQueryHandler(_mockDatabase);
    //        _DeleteCatByIDCommandHandler = new DeleteCatByIdCommandHandler(_mockDatabase);
    //    }

    //    [Test]
    //    public async Task Before_Is_Not_Null_After_Is_Null_And_Result_Test()
    //    {
    //        // Arrange
    //        var catID = new Guid("02345678-1234-5678-1234-567812345678");

    //        var queryDeleteCatByID = new DeleteCatByIDCommand(catID);
    //        var queryGetCatByID = new GetCatByIDQuery(catID);

    //        // Act
    //        var resultGetCatByIDBefore = await _GetCatByIDQueryHandler.Handle(queryGetCatByID, CancellationToken.None);
    //        var result = await _DeleteCatByIDCommandHandler.Handle(queryDeleteCatByID, CancellationToken.None);
    //        var resultGetCatByIDAfter = await _GetCatByIDQueryHandler.Handle(queryGetCatByID, CancellationToken.None);

    //        // Assert
    //        Assert.NotNull(resultGetCatByIDBefore);
    //        Assert.IsNull(resultGetCatByIDAfter);
    //        Assert.That(result.DogID, Is.EqualTo(catID));
    //    }
    //}
}