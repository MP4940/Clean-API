﻿using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Queries.Animals.Birds.GetBirdsByColor
{
    public class GetBirdsByColorQueryHandler : IRequestHandler<GetBirdsByColorQuery, List<Bird>>
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdsByColorQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetBirdsByColorQuery request, CancellationToken cancellationToken)
        {
            List<Bird> birdsByColor = await _birdRepository.GetBirdsByColor(request.Color);
            return birdsByColor;
        }
    }
}