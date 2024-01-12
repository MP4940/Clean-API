using Application.Dtos.AnimalUserDto;
using Application.Queries.AnimalUsers.GetAllAnimalUsers;
using Domain.Models.Animals;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.GetAllAnimalUsers
{
    [TestFixture]
    public class GetAllAnimalUsersTests
    {
        private Mock<IAnimalUserRepository> _animalUserRepositoryMock;
        private GetAllAnimalUsersQueryHandler _getAllAnimalUsersQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _animalUserRepositoryMock = new Mock<IAnimalUserRepository>();
            _getAllAnimalUsersQueryHandler = new GetAllAnimalUsersQueryHandler(_animalUserRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllAnimalUsers_Returns_Correct()
        {
            // Arrange
            List<GetAllAnimalUsersDto> getAllAnimalUsersDtos =
            [
                new GetAllAnimalUsersDto() { AnimalName = "testAnimalName1", Username = "testUsername1" },
                new GetAllAnimalUsersDto() { AnimalName = "testAnimalName2", Username = "testUsername2" }
            ];

            _animalUserRepositoryMock.Setup(x => x.GetAllAnimalUsers()).ReturnsAsync(getAllAnimalUsersDtos);

            var query = new GetAllAnimalUsersQuery();

            // Act
            var result = await _getAllAnimalUsersQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<GetAllAnimalUsersDto>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}