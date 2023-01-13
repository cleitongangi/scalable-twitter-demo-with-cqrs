using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TwitterDemo.API.Controllers;
using TwitterDemo.Domain.Commands.Posts.NewPost;

namespace TwitterDemo.API.Tests.Controllers
{
    public class PostsControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock = new();

        [Fact]
        public async Task ListPlanets_WithData_ReturnOk()
        {
            // Arrange
            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<NewPostCommand>(), default(CancellationToken)))
                .ReturnsAsync(new NewPostResult() { Id = 1, CreatedAt = DateTime.Now, Text = "Test" });

            var controller = new PostsController(_mediatorMock.Object);

            // Act
            var result = await controller.NewPost(new NewPostCommand() { Text = "Test" });
            var createdResult = result as CreatedResult;

            // Assert
            Assert.NotNull(createdResult);
            Assert.Equal(StatusCodes.Status201Created, createdResult?.StatusCode);
        }

        [Fact]
        public async Task ListPlanets_WithData_ReturnBadRequest()
        {
            // Arrange
            var newPostResult = new NewPostResult() { Id = 1, CreatedAt = DateTime.Now };
            newPostResult.AddError("Unit test");

            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<NewPostCommand>(), default(CancellationToken)))
                .ReturnsAsync(newPostResult);

            var controller = new PostsController(_mediatorMock.Object);

            // Act
            var result = await controller.NewPost(new NewPostCommand() { Text = "Test" });
            var badRequestResult = result as BadRequestObjectResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult?.StatusCode);
        }
    }
}
