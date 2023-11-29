﻿using Domain.Models.Animals.Birds;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Animals.Birds.GetBirdByID
{
    public class GetBirdByIDQueryHandler : IRequestHandler<GetBirdByIDQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;
        public GetBirdByIDQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(GetBirdByIDQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _mockDatabase.AllBirds.Where(Bird => Bird.AnimalID == request.ID).FirstOrDefault()!;
            return Task.FromResult(wantedBird);
        }
    }
}