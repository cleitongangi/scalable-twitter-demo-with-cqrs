using AutoMapper;
using TwitterDemo.Domain.Commands.Posts.NewPost;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.API.Configurations.AutoMapper.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PostEntity, NewPostResult>(MemberList.None);
        }
    }
}
