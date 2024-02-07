using Domain.Models.Animals.Dogs;
using Infrastructure.Repositories.Animals.Dogs;
using MediatR;

namespace Application.Commands.Animals.Dogs.DeleteDog
{
    public class DeleteDogByIDCommandHandler : IRequestHandler<DeleteDogByIDCommand, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public DeleteDogByIDCommandHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<Dog> Handle(DeleteDogByIDCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _dogRepository.GetDogByID(request.ID).Result;

            var deletedDog = await _dogRepository.DeleteDog(dogToDelete);

            return deletedDog;
        }
    }
}