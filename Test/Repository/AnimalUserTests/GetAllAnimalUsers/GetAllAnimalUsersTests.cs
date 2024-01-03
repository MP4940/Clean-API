using Application.Queries.AnimalUsers;
using Domain.Models.Animals;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.GetAllAnimalUsers
{
    [TestFixture]
    internal class GetAllAnimalUsersTests
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
            List<AnimalUser> animalUsers =
            [
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345675") },
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345676"), UserID = new Guid("12345678-1234-5678-1234-567812345677") }
            ];
            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345675"), Username = "testUser1", Password = "password", Authorized = true, Role = "admin", },
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345677"), Username = "testUser2", Password = "Password123!", Authorized = true, Role = "admin" }
            ];
            List<Animal> animals =
            [
                new Animal() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "testDog1", Type = "Dog" },
                new Animal() { AnimalID = new Guid("12345678-1234-5678-1234-567812345676"), Name = "testCat1", Type = "Cat" }
            ];

            _animalUserRepositoryMock.Setup(x => x.GetAllAnimalUsers()).ReturnsAsync(animalUsers);

            var query = new GetAllAnimalUsersQuery();

            // Act
            var result = await _getAllAnimalUsersQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<AnimalUser>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}