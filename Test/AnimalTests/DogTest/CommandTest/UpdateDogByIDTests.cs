using Application.Commands.Animals.Dogs.UpdateDog;
using Application.Dtos.AnimalsDtos.DogDto;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    //[TestFixture]
    //public class UpdateDogByIDTests
    //{
    //    private MockDatabase _mockDatabase;
    //    private UpdateDogByIdCommandHandler _UpdateDogByIDDogCommandHandler;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        // Initialize the handler and mock database before each test
    //        _mockDatabase = new MockDatabase();
    //        _UpdateDogByIDDogCommandHandler = new UpdateDogByIdCommandHandler(_mockDatabase);
    //    }

    //    [Test]
    //    public async Task NotNull_And_Values_Updated_Correctly()
    //    {
    //        // Arrange
    //        var dogID = new Guid("12345678-1234-5678-1234-567812345678");
    //        DogDto dogDto = new DogDto { Name = "UpdatedDogName" };

    //        var query = new UpdateDogByIDCommand(dogDto, dogID);

    //        // Act
    //        var result = await _UpdateDogByIDDogCommandHandler.Handle(query, CancellationToken.None);

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.That(result.Name, Is.EqualTo(dogDto.Name));
    //    }
    //}
}