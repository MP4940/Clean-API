using Application.Queries.Users.GetUserByID;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.UserTests.GetUserByID
{
    [TestFixture]
    public class GetUserByIDTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private GetUserByIDQueryHandler _getUserByIDQueryHandler;

        [SetUp]
        public void SetUp()
        {
            //Ändra till UserRepos?
            _userRepositoryMock = new Mock<IUserRepository>();
            _getUserByIDQueryHandler = new GetUserByIDQueryHandler(_userRepositoryMock.Object);
        }

        [Test]
        public async Task GetUserByID_Returns_Correct()
        {
            // Arrange

            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { ID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var wantedUser = users.Where(user => user.ID == ID).FirstOrDefault()!;

            _userRepositoryMock.Setup(x => x.GetUserByID(ID)).ReturnsAsync(wantedUser);

            var query = new GetUserByIDQuery(ID);

            // Act
            var result = await _getUserByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ID, Is.EqualTo(ID));
        }
        [Test]
        public async Task Returns_Null()
        {
            // Arrange
            var invalidUserId = Guid.NewGuid();

            var query = new GetUserByIDQuery(invalidUserId);

            // Act
            var result = await _getUserByIDQueryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}