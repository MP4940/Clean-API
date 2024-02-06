using API.Controllers.UsersController;
using Application.Commands.Users.Register;
using Application.Dtos.UserDtos;
using Application.Validators;
using Application.Validators.User;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test.ControllerTests
{
    //[TestFixture]
    //public class UserControllerTests
    //{
    //    private Mock<IMediator> _mediatorMock;
    //    private UsersController _controller;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _mediatorMock = new Mock<IMediator>();
    //        _controller = CreateControllerInstance();
    //    }

    //    private UsersController CreateControllerInstance()
    //    {

    //        return new UsersController(_mediatorMock.Object);
    //    }

    //    [Test]
    //    public async Task WHEN_RegisterUser_THEN_Success()
    //    {
    //        var newUser = new UserCredentialsDto() { Username = "testUserForintegrationTest", Password = "password123", Role = "admin" };

    //        // Arrange
    //        _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
    //            .ReturnsAsync(new User
    //            {
    //                ID = Guid.NewGuid(),
    //                Username = newUser.Username,
    //                Password = newUser.Password,
    //                Authorized = true
    //            });

    //        // Act
    //        var result = await _controller.Register(newUser);

    //        // Assert
    //        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    //    }
    //}
}