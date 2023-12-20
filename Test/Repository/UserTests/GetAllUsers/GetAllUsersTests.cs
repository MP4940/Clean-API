using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using Application.Queries.Users.GetAllUsers;
using Moq;

namespace Test.Repository.UserTests.GetAllUsers
{
    //[TestFixture]
    //internal class GetAllUsersTests
    //{
    //    private Mock<IUserRepository> _userRepositoryMock;
    //    private GetAllUsersQueryHandler _handler;

    //    [SetUp]
    //    public void SetUp()
    //    {
    //        _userRepositoryMock = new Mock<IUserRepository>();
    //        _handler = new GetAllUsersQueryHandler(_userRepositoryMock.Object);
    //    }

    //    [Test]
    //    public async Task GetAllUsers_returns_correct()
    //    {
    //        // Arrange
    //        _userRepositoryMock.Object.GetAllUsers();

    //        var query = new GetAllUsersQuery();

    //        // Act
    //        var result = await _handler.Handle(query, CancellationToken.None);

    //        // Assert
    //        Assert.That(result, Is.Not.Null);
    //        Assert.That(result, Is.InstanceOf<List<User>>());
    //        Assert.That(result, Is.Not.Empty);
    //    }
    //}
}