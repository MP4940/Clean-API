using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using Moq;

namespace Test.Repository.CatTests.DeleteCatByID
{
    [TestFixture]
    internal class DeleteCatByIDTests
    {
        private CatRepository _catRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _catRepository = new CatRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Cats.Remove(It.IsAny<Cat>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }

        [Test]
        public async Task Cat_Deleted()
        {
            // Arrange
            List<Cat> cats =
            [
                new Cat() { CatID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestCat1" },
                new Cat() { CatID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestCat2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var catToDelete = cats.Where(cat => cat.CatID == ID).FirstOrDefault();

            var result = await _catRepository.DeleteCat(catToDelete!);

            Assert.NotNull(result);
            _mockRealDatabase.Verify(db => db.Cats.Remove(It.IsAny<Cat>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task Cat_Not_Found()
        {
            // Arrange
            List<Cat> cats =
            [
                new Cat() { CatID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestCat1" },
                new Cat() { CatID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestCat2" },
            ];
            var invalidID = Guid.NewGuid();

            var catToDelete = cats.Where(Cat => Cat.CatID == invalidID).FirstOrDefault();

            var result = await _catRepository.DeleteCat(catToDelete!);

            Assert.Null(result);
        }
    }
}