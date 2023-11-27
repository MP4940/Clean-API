using Application.Commands.Animals.Cats.AddCat;
using Application.Dtos.AnimalsDtos.CatDto;
using Application.Queries.Animals.Cats.GetCatByID;
using Infrastructure.Database;

namespace Test.AnimalTests.CatTest.CommandTest
{
    public class AddCatTest
    {
        private MockDatabase _mockDatabase;
        private GetCatByIDQueryHandler _GetCatByIDQueryHandler;
        private AddCatCommandHandler _AddCatCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetCatByIDQueryHandler = new GetCatByIDQueryHandler(_mockDatabase);
            _AddCatCommandHandler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Added_Cat_Is_Correct(bool likesToPlay)
        {
            // Arrange
            CatDto CatDto = new CatDto { Name = "AddedCatTestName", LikesToPlay = likesToPlay };

            var query = new AddCatCommand(CatDto);

            // Act
            var result = await _AddCatCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(CatDto.Name));
            Assert.That(result.LikesToPlay, Is.EqualTo(CatDto.LikesToPlay));
        }
    }
}