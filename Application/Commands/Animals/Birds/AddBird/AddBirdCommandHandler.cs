using Domain.Models.Animals.Birds;
using Infrastructure.Repositories.Animals.Birds;
using MediatR;

namespace Application.Commands.Animals.Birds.AddBird
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly IBirdRepository _birdRepository;
        private readonly AddBirdCommandValidator _validator;

        public AddBirdCommandHandler(IBirdRepository birdRepository, AddBirdCommandValidator validator)
        {
            _birdRepository = birdRepository;
            _validator = validator;
        }

        public async Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            var addCommandValidation = _validator.Validate(request);

            if (!addCommandValidation.IsValid)
            {
                var allErrors = addCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            //var AnimalID = Guid.NewGuid();

            // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
            var BirdToCreate = new Bird
            {
                AnimalID = Guid.NewGuid(),
                Name = request.NewBird.Name,
                CanFly = request.NewBird.CanFly,
                Color = request.NewBird.Color
            };

            //var animalToCreate = new Animal 
            //{ 
            //    AnimalID = AnimalID,
            //    Name = request.NewBird.Name,
            //    Type = "Bird"
            //};

            var createdBird = await _birdRepository.AddBird(BirdToCreate);

            return createdBird;
        }
    }
}