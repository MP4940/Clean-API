using Domain.Models.Animals;
using Domain.Models.AnimalUsers;
using Domain.Models.Users;
using Infrastructure.Database;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.CreateAnimalUsers
{
    [TestFixture]
    internal class CreateAnimalUserTests
    {
        private AnimalUserRepository _animalUserRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.AnimalUsers.Add(It.IsAny<AnimalUser>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _animalUserRepository = new AnimalUserRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task Create_AnimalUser_Success()
        {
            // Arrange
            List<User> users =
            [
                new User() { ID = new Guid("12345678-1234-5678-1234-567812345675"), Username = "testUser2", Password = "password", Authorized = true, Role = "admin" },
                new User() { ID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Username = "admin1", Password = "Password123!", Authorized = true, Role = "admin" },
            ];
            List<Animal> animals =
            [
                new Animal() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "testAnimal1", Type = "Dog" },
                new Animal() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "testAnimal2", Type = "Cat" },
            ];

            var animalUserToCreate = new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345675") };

            // Act
            var createdAnimalUser = await _animalUserRepository.CreateAnimalUser(animalUserToCreate);

            // Assert
            Assert.NotNull(createdAnimalUser);
            Assert.That(createdAnimalUser.AnimalID, Is.EqualTo(animalUserToCreate.AnimalID));
            Assert.That(createdAnimalUser.UserID, Is.EqualTo(animalUserToCreate.UserID));
            _mockRealDatabase.Verify(db => db.AnimalUsers.Add(It.IsAny<AnimalUser>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}