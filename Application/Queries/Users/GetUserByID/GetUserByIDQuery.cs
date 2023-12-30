using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.GetUserByID
{
    public class GetUserByIDQuery : IRequest<User>
    {
        public GetUserByIDQuery(Guid userID)
        {
            ID = userID;
        }
        public Guid ID { get; set; }
    }
}