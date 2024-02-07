using Domain.Models.Animals.Cats;
using Infrastructure.Database;
using Infrastructure.Repositories.Animals.Cats;
using Moq;

namespace Test.Repository.CatTests.UpdateCatByID
{
    [TestFixture]
    public class UpdateCatByIDTests
    {
        private CatRepository _CatRepository;
        private Mock<RealDatabase> _mockRealDatabase = new Mock<RealDatabase>();

        [SetUp]
        public void SetUp()
        {
            _CatRepository = new CatRepository(_mockRealDatabase.Object);
            _mockRealDatabase.Setup(db => db.Cats.Update(It.IsAny<Cat>()));
            _mockRealDatabase.Setup(db => db.SaveChanges());
        }
        [Test]
        public async Task Values_Updated_Correctly()
        {
            // Arrange
            List<Cat> Cats =
            [
                new Cat() { AnimalID = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestCat1", Breed = "Pudel", Weight = 3 },
                new Cat() { AnimalID = new Guid("34d621a5-9f60-4647-bcb7-adcfdbd8dbdb"), Name = "TestCat2" },
            ];

            var ID = new Guid("12345678-1234-5678-1234-567812345674");

            var CatToUpdate = Cats.Where(Cat => Cat.AnimalID == ID).FirstOrDefault()!;

            CatToUpdate.Name = "updatedCatname";
            CatToUpdate.Breed = "updatedBreed";
            CatToUpdate.Weight = 66;

            // Act
            var result = await _CatRepository.UpdateCat(CatToUpdate);

            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(CatToUpdate.Name));
            Assert.That(result.Breed, Is.EqualTo(CatToUpdate.Breed));
            Assert.That(result.Weight, Is.EqualTo(CatToUpdate.Weight));
            _mockRealDatabase.Verify(db => db.Cats.Update(It.IsAny<Cat>()), Times.Once);
            _mockRealDatabase.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
