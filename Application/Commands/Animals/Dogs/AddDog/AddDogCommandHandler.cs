﻿using Domain.Models.Animals.Dogs;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Animals.Dogs.AddDog
{
    internal sealed class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public AddDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                AnimalID = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _mockDatabase.allDogs.Add(dogToCreate);

            return Task.FromResult(dogToCreate);
        }
    }
}