using Application.Commands.Animals.Dogs.AddDog;
using Application.Dtos.AnimalsDtos.DogDto;
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