using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        private readonly AddDogCommandValidator _validator;

        public AddDogCommandHandler(IDogRepository dogRepository, AddDogCommandValidator validator)
        {
            _dogRepository = dogRepository;
            _validator = validator;
        }

        public async Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            var addCommandValidation = _validator.Validate(request);

            if (!addCommandValidation.IsValid)
            {
                var allErrors = addCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            //var dogID = Guid.NewGuid();

            // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
            var dogToCreate = new Dog
            {
                AnimalID = Guid.NewGuid(),
                Name = request.NewDog.Name,
                Breed = request.NewDog.Breed,
                Weight = request.NewDog.Weight
            };

            //var animalToCreate = new Animal 
            //{ 
            //    AnimalID = dogID,
            //    Name = request.NewDog.Name,
            //    Type = "Dog"
            //};

            var createdDog = await _dogRepository.AddDog(dogToCreate);

            return createdDog;
        }
    }
}