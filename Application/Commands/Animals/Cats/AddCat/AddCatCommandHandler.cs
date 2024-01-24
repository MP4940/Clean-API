using Domain.Models.Animals.Cats;
using Infrastructure.Repositories.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.AddCat
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly ICatRepository _catRepository;
        private readonly AddCatCommandValidator _validator;

        public AddCatCommandHandler(ICatRepository catRepository, AddCatCommandValidator validator)
        {
            _catRepository = catRepository;
            _validator = validator;
        }

        public async Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            var addCommandValidation = _validator.Validate(request);

            if (!addCommandValidation.IsValid)
            {
                var allErrors = addCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            //var AnimalID = Guid.NewGuid();

            // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
            var catToCreate = new Cat
            {
                AnimalID = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay,
                Breed = request.NewCat.Breed,
                Weight = request.NewCat.Weight
            };

            //var animalToCreate = new Animal 
            //{ 
            //    AnimalID = AnimalID,
            //    Name = request.NewCat.Name,
            //    Type = "Cat"
            //};

            var createdCat = await _catRepository.AddCat(catToCreate);

            return createdCat;
        }
    }
}