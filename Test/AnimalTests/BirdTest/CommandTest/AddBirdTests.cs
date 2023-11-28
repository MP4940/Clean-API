﻿using Application.Commands.Animals.Birds.AddBird;
using Application.Dtos.AnimalsDtos.BirdDto;
using Application.Queries.Animals.Birds.GetBirdByID;
using Infrastructure.Database;

namespace Test.AnimalTests.BirdTest.CommandTest
{
    public class AddBirdTests
    {
        private MockDatabase _mockDatabase;
        private GetBirdByIDQueryHandler _GetBirdByIDQueryHandler;
        private AddBirdCommandHandler _AddBirdCommandHandler;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _GetBirdByIDQueryHandler = new GetBirdByIDQueryHandler(_mockDatabase);
            _AddBirdCommandHandler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task Added_Bird_Is_Correct(bool canFly)
        {
            // Arrange
            BirdDto birdDto = new BirdDto { Name = "AddedBirdTestName", CanFly = canFly };

            var query = new AddBirdCommand(birdDto);

            // Act
            var result = await _AddBirdCommandHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(birdDto.Name));
            Assert.That(result.CanFly, Is.EqualTo(birdDto.CanFly));
        }
    }
}