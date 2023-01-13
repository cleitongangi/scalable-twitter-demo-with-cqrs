using FluentValidation;

namespace TwitterDemo.Domain.Commands.Posts.NewPost
{
    public class NewPostValidation : AbstractValidator<NewPostCommand>
    {
        public NewPostValidation()
        {
            RuleFor(x => x.Text)
                .NotEmpty()                
                .MaximumLength(1000);

            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
