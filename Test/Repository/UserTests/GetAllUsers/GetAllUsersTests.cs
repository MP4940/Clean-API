using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using Application.Queries.Users.GetAllUsers;
using Moq;

namespace Test.Repository.UserTests.GetAllUsers
{
    [TestFixture]
    internal class GetAllUsersTests
    { 
        private Mock<IUserRepository> _userRepositoryMock;
        private GetAllUsersQueryHandler _getAllUsersQueryHandler;

        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _getAllUsersQueryHandler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
        }

        [Test]
        public async Task GetAlLDogs_Returns_Correct()
        {
            // Arrange
            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { ID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];


            _userRepositoryMock.Setup(x => x.GetAllUsers()).ReturnsAsync(users);

            var query = new GetAllUsersQuery();

            // Act
            var result = await _getAllUsersQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<User>>());
            Assert.That(result, Is.Not.Empty);
        }
    }
}