using Domain.Models.Animals.Cats;
using MediatR;

namespace Application.Commands.Animals.Cats.DeleteCat
{
    public class DeleteCatByIDCommand : IRequest<Cat>
    {
        public DeleteCatByIDCommand(Guid catID)
        {
            ID = catID;
        }
        public Guid ID { get; set; }
    }
}