using Application.Dtos.AnimalsDtos.CatDto;
using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.AddCat
{
    public class AddCatCommand : IRequest<Cat>
    {
        public AddCatCommand(CatDto newCat)
        {
            NewCat = newCat;
        }
        public CatDto NewCat { get; }
    }
}