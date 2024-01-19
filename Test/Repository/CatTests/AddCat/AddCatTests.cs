using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using Moq;

namespace Test.Repository.CatTests.AddCat
{
    [TestFixture]
    internal class AddCatTests
    {
        private CatRepository _catRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockRealDatabase.Setup(db => db.Cats.Add(It.IsAny<Cat>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
            _catRepository = new CatRepository(_mockRealDatabase.Object);
        }
        [Test]
        public async Task AddCat_Success()
        {
            // Arrange
            var catToAdd = new Cat() { CatID = Guid.NewGuid(), Name = "TestCat3" };

            // Act
            var addedCat = await _catRepository.AddCat(catToAdd);

            // Assert
            Assert.NotNull(addedCat);
            Assert.That(addedCat.CatID, Is.EqualTo(catToAdd.CatID));
            Assert.That(addedCat.Name, Is.EqualTo(catToAdd.Name));
            _mockRealDatabase.Verify(db => db.Cats.Add(It.IsAny<Cat>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}