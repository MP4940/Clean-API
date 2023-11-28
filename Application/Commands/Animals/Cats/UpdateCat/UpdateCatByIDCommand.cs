using Application.Dtos.AnimalsDtos.CatDto;
using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.UpdateCat
{
    public class UpdateCatByIDCommand : IRequest<Cat>
    {
        public UpdateCatByIDCommand(CatDto updatedCat, Guid id)
        {
            UpdatedCat = updatedCat;
            ID = id;
        }
        public CatDto UpdatedCat { get; }
        public Guid ID { get; }
    }
}