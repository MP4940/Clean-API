using Domain.Models.Animals.Dogs;
using Infrastructure.Database;

namespace Test.DogTest
{
    [TestFixture]
    public class DogTest
    {
        [TestCase("Bark")]
        public void TestMethodBark(string expected)
        {
            // Act
            Dog dog = new Dog();
            string actual = dog.Bark();

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}