using Application.Commands.Animals.Cats.AddCat;
using Application.Dtos.AnimalsDtos.CatDto;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.CommandTest
{
    public class AddCatTests
    {
        private MockDatabase _mockDatabase;
        private AddCatCommandHandler _AddCatCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _AddCatCommandHandler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Added_Cat_Is_Not_Null_And_Correct(bool likesToPlay)
        {
            // Arrange
            CatDto catDto = new CatDto { Name = "AddedCatTestName", LikesToPlay = likesToPlay };

            var query = new AddCatCommand(catDto);

            // Act
            var result = await _AddCatCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(catDto.Name));
            Assert.That(result.LikesToPlay, Is.EqualTo(catDto.LikesToPlay));
        }
    }
}