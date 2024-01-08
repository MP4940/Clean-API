using Domain.Models.Animals;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Database;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.UpdateAnimalUsers
{
    [TestFixture]
    public class UpdateAnimalUsersTests
    {
        private AnimalUserRepository _animalUserRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _animalUserRepository = new AnimalUserRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.AnimalUsers.Update(It.IsAny<AnimalUser>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task Values_Updated_Correctly()
        {
            // Arrange
            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345671"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345672"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];
            List<Animal> animals =
            [
                new Animal() { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), Name = "testAnimal1", Type = "Dog" },
                new Animal() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "testAnimal2", Type = "Cat" },
            ];
            List<AnimalUser> animalUsers =
            [
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345671"), Key = new Guid("12345678-1234-5678-1234-567812345675") },
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), UserID = new Guid("12345678-1234-5678-1234-567812345672"), Key = new Guid("12345678-1234-5678-1234-567812345676") },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345675");

            var animalUserToUpdate = animalUsers.Where(animalUser => animalUser.Key == ID).FirstOrDefault()!;

            animalUserToUpdate.AnimalID = new Guid("12345678-1234-5678-1234-567812345673");
            animalUserToUpdate.UserID = new Guid("12345678-1234-5678-1234-567812345675");

            // Act

            var result = await _animalUserRepository.UpdateAnimalUser(animalUserToUpdate);

            Assert.NotNull(result);
            Assert.That(result.AnimalID, Is.EqualTo(animalUserToUpdate.AnimalID));
            Assert.That(result.UserID, Is.EqualTo(animalUserToUpdate.UserID));
            _mockRealDatabase.Verify(db => db.AnimalUsers.Update(It.IsAny<AnimalUser>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}