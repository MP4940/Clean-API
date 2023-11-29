using Application.Commands.Animals.Dogs.AddDog;
using Application.Dtos.AnimalsDtos.DogDto;
using Infrastructure.Database;

namespace Test.AnimalTests.DogTest.CommandTest
{
    public class AddDogTests
    {
        private MockDatabase _mockDatabase;
        private AddDogCommandHandler _AddDogCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _AddDogCommandHandler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Added_Dog_Is_Not_Null_And_Correct()
        {
            // Arrange
            DogDto dogDto = new DogDto { Name = "AddedDogTestName" };

            var query = new AddDogCommand(dogDto);

            // Act
            var result = await _AddDogCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
        }
    }
}