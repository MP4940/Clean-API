using Domain.Models.Users;
using Infrastructure.Database;
using Infrastructure.Repositories.Users;
using Moq;

namespace Test.Repository.UserTests.UpdateUser
{
    [TestFixture]
    public class UpdateUserTests
    {
        private UserRepository _userRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _userRepository = new UserRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Users.Update(It.IsAny<User>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task Values_Updated_CorrectlyAsync()
        {
            // Arrange
            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345674"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { ID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var wantedUser = users.Where(user => user.ID == ID).FirstOrDefault()!;

            wantedUser.Username = "updatedUsername";
            wantedUser.Password = "updatedPassword123!";
            wantedUser.Role = "updatedRole";

            // Act

            var result = await _userRepository.UpdateUser(wantedUser);

            Assert.NotNull(result);
            Assert.That(result.Username, Is.EqualTo(wantedUser.Username));
            Assert.That(result.Password, Is.EqualTo(wantedUser.Password));
            Assert.That(result.Role, Is.EqualTo(wantedUser.Role));
            _mockRealDatabase.Verify(db => db.Users.Update(It.IsAny<User>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}