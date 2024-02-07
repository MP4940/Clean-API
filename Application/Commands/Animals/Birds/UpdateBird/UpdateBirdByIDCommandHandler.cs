using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.UpdateBird
{
    public class UpdateBirdByIDCommandHandler : IRequestHandler<UpdateBirdByIDCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;
        private readonly UpdateBirdByIDCommandValidator _validator;
        public UpdateBirdByIDCommandHandler(IBirdRepository birdRepository, UpdateBirdByIDCommandValidator validator)
        {
            _birdRepository = birdRepository;
            _validator = validator;
        }
        public async Task<Bird> Handle(UpdateBirdByIDCommand request, CancellationToken cancellationToken)
        {
            var updateBirdByIDCommandValidation = _validator.Validate(request);

            if (!updateBirdByIDCommandValidation.IsValid)
            {
                var allErrors = updateBirdByIDCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Update error: " + string.Join("; ", allErrors));
            }

            Bird birdToUpdate = _birdRepository.GetBirdByID(request.ID).Result;

            birdToUpdate.Name = request.UpdatedBird.Name;
            birdToUpdate.CanFly = request.UpdatedBird.CanFly;
            birdToUpdate.Color = request.UpdatedBird.Color;

            var updatedBird = await _birdRepository.UpdateBird(birdToUpdate);

            return updatedBird;
        }
    }
}