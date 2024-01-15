using Application.Queries.Users.GetAnimalUserByID;
using Domain.Models.AnimalUsers;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.GetAnimalUserByID
{
    [TestFixture]
    public class GetAnimalUserByIDTests
    {
        private Mock<IAnimalUserRepository> _animalUserRepositoryMock;
        private GetAnimalUserByIDQueryHandler _getAnimalUserByIDQueryHandler;

        [SetUp]
        public void SetUp()
        {
            //Ändra till UserRepos?
            _animalUserRepositoryMock = new Mock<IAnimalUserRepository>();
            _getAnimalUserByIDQueryHandler = new GetAnimalUserByIDQueryHandler(_animalUserRepositoryMock.Object);
        }

        [Test]
        public async Task GetAnimalUserByID_Returns_Correct()
        {
            // Arrange

            List<AnimalUser> animalUsers =
        [
            new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345671"), Key = new Guid("12345678-1234-5678-1234-567812345675") },
            new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), UserID = new Guid("12345678-1234-5678-1234-567812345672"), Key = new Guid("12345678-1234-5678-1234-567812345676") },
        ];

            var key = new Guid("12345678-1234-5678-1234-567812345676");

            var wantedAnimalUser = animalUsers.Where(user => user.Key == key).FirstOrDefault()!;

            _animalUserRepositoryMock.Setup(x => x.GetAnimalUserByID(key)).ReturnsAsync(wantedAnimalUser);

            var query = new GetAnimalUserByIDQuery(key);

            // Act
            var result = await _getAnimalUserByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Key, Is.EqualTo(key));
        }
        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidAnimalUserID = Guid.NewGuid();

            var query = new GetAnimalUserByIDQuery(invalidAnimalUserID);

            // Act
            var result = await _getAnimalUserByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}