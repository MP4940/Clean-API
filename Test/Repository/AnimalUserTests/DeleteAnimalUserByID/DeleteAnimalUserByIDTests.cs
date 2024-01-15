using Domain.Models.AnimalUsers;
using Infrastructure.Database;
using Infrastructure.Repositories.AnimalUsers;
using Moq;

namespace Test.Repository.AnimalUserTests.DeleteAnimalUserByID
{
    [TestFixture]
    internal class DeleteAnimalUserByIDTests
    {
        private AnimalUserRepository _animalUserRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _animalUserRepository = new AnimalUserRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.AnimalUsers.Remove(It.IsAny<AnimalUser>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task AnimalUser_Deleted()
        {
            // Arrange
            List<AnimalUser> animalUsers =
            [
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345671"), Key = new Guid("12345678-1234-5678-1234-567812345675") },
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), UserID = new Guid("12345678-1234-5678-1234-567812345672"), Key = new Guid("12345678-1234-5678-1234-567812345676") },
            ];

            var key = new Guid("12345678-1234-5678-1234-567812345675");

            var animalUserToDelete = animalUsers.Where(animalUser => animalUser.Key == key).FirstOrDefault();

            var result = await _animalUserRepository.DeleteAnimalUser(animalUserToDelete!);

            Assert.NotNull(result);
            _mockRealDatabase.Verify(db => db.AnimalUsers.Remove(It.IsAny<AnimalUser>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task AnimalUser_Not_Found()
        {
            // Arrange
            List<AnimalUser> animalUsers =
            [
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), UserID = new Guid("12345678-1234-5678-1234-567812345671"), Key = new Guid("12345678-1234-5678-1234-567812345675") },
                new AnimalUser() { AnimalID = new Guid("12345678-1234-5678-1234-567812345673"), UserID = new Guid("12345678-1234-5678-1234-567812345672"), Key = new Guid("12345678-1234-5678-1234-567812345676") },
            ];

            var invalidKey = Guid.NewGuid();

            var animalUserToDelete = animalUsers.Where(animalUser => animalUser.Key == invalidKey).FirstOrDefault();

            // Act
            var result = await _animalUserRepository.DeleteAnimalUser(animalUserToDelete!);

            // Assert
            Assert.Null(result);
        }
    }
}