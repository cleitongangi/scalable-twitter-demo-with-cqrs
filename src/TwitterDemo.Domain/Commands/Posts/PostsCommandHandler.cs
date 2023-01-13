using AutoMapper;
using FluentValidation;
using MediatR;
using TwitterDemo.Domain.Commands.Posts.NewPost;
using TwitterDemo.Domain.Interfaces.Data;
using TwitterDemo.Domain.Interfaces.Repositories;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Domain.Commands.Posts
{
    public class PostsCommandHandler :
        IRequestHandler<NewPostCommand, NewPostResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPostsRepository _postsRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<NewPostCommand> _newPostValidation;

        public PostsCommandHandler(IUnitOfWork unitOfWork, IPostsRepository postsRepository, IMapper mapper, IValidator<NewPostCommand> newPostValidation)
        {
            this._uow = unitOfWork;
            this._postsRepository = postsRepository;
            this._mapper = mapper;
            this._newPostValidation = newPostValidation;
        }

        public async Task<NewPostResult> Handle(NewPostCommand request, CancellationToken cancellationToken)
        {
            var validation = _newPostValidation.Validate(request);

            if (!validation.IsValid)
            {
                var result = new NewPostResult();
                result.AddError(validation.Errors);
                return result;
            }

            var newPost = PostEntity.Factory.NewPost(request);
            await _postsRepository.AddAsync(newPost);
            await _uow.SaveChangesAsync();
            return _mapper.Map<NewPostResult>(newPost);
        }
    }
}
