using Domain.Models.Animals.Dogs;
using Infrastructure.Database;

namespace Test.DogTest
{
    [TestFixture]
    public class DogTest
    {
        //private readonly MockDatabase _mockDatabase;
        [TestCase("Bark")]
        public void TestMethodBark(string expected)
        {
            // Act
            Dog dog = new Dog();
            string actual = dog.Bark();

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
        // Ta in från mockDB listan
        [TestCase("Stanley")]
        public void TestMockDatabaseDogName(string expected)
        {
            // Testa mockDatabase dog name mot API
            MockDatabase _mockDatabase = new MockDatabase();

            // Act
            // få in svar från mockDB
            string actual = _mockDatabase.allDogs.FirstOrDefault().Name;

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        // Testa mockDatabase dog Guid mot APi
    }
}