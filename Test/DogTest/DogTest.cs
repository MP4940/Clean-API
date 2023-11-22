using Domain.Models.Animals.Dogs;
using Infrastructure.Database;

namespace Test.DogTest
{
    [TestFixture]
    public class DogTest
    {
        [TestCase("Stanley")]
        public void TestMockDatabaseDogName(string expected)
        {
            MockDatabase _mockDatabase = new MockDatabase();
            string actual = _mockDatabase.allDogs.FirstOrDefault().Name;

            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}