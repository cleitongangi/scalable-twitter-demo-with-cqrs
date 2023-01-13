using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterDemo.Domain.Commands.Posts;
using TwitterDemo.Domain.Commands.Posts.NewPost;

namespace TwitterDemo.Domain.Tests.Commands.Posts.NewPost
{
    public class NewPostValidationTest
    {
        [Fact]
        public void Validation_ValidData_IsValidTrue()
        {
            // Arrange
            var validation = new NewPostValidation();
            var newPostCommand = new NewPostCommand()
            {
                Text = "Unit test"
            };
            newPostCommand.SetUserId(1);

            // Act
            var validationResult = validation.Validate(newPostCommand);

            // Assert
            Assert.True(validationResult.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidationTextRequired_TextInvalid_IsValidFalse(string? text)
        {
            // Arrange
            var validation = new NewPostValidation();
            var newPostCommand = new NewPostCommand()
            {
                Text = text
            };
            newPostCommand.SetUserId(1);

            // Act
            var validationResult = validation.Validate(newPostCommand);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Any(x => x.ErrorMessage.Equals("'Text' must not be empty.")));
        }

        [Theory]
        [InlineData(0)]        
        [InlineData(-1)]
        public void ValidationUserIdRequired_UserIdInvalid_IsValidFalse(long userId)
        {
            // Arrange
            var validation = new NewPostValidation();
            var newPostCommand = new NewPostCommand()
            {
                Text = "Unit test"
            };
            newPostCommand.SetUserId(userId);

            // Act
            var validationResult = validation.Validate(newPostCommand);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.True(validationResult.Errors.Any(x => x.ErrorMessage.Equals("'User Id' must be greater than '0'.")));
        }
    }
}
