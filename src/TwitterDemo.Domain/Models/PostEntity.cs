using TwitterDemo.Domain.Commands.Posts.NewPost;
using TwitterDemo.Domain.Enum;

namespace TwitterDemo.Domain.Models
{
    public class PostEntity
    {
        public long Id { get; set; } // id (Primary key)
        public string? Text { get; set; } // text (length: 777)
        public DateTime CreatedAt { get; set; } // created_at
        public long UserId { get; set; } // user_id
        public long? ParentId { get; set; } // parent_id
        public int TypeId { get; set; } // type_id

        // Reverse navigation

        /// <summary>
        /// Child Posts where posts.parent_id point to this entity fk_post_post_parent
        /// </summary>
        public virtual ICollection<PostEntity> Posts { get; set; } // posts.fk_post_post_parent

        // Foreign keys

        /// <summary>
        /// Parent Post pointed by Posts.(parent_id) (fk_posts_post_parent)
        /// </summary>
        public virtual PostEntity? Parent { get; set; } // fk_post_post_parent

        /// <summary>
        /// Parent PostType pointed by posts.(type_id) (fk_post_posttype)
        /// </summary>
        public virtual PostTypeEntity? PostType { get; set; } // fk_post_post_type

        /// <summary>
        /// Parent User pointed by posts.(user_id) (fk_posts_users)
        /// </summary>
        public virtual UserAccountEntity? User { get; set; } // fk_posts_user

        public PostEntity()
        {
            Posts = new List<PostEntity>();
        }

        public static class Factory
        {
            public static PostEntity NewPost(NewPostCommand command)
            {
                return new PostEntity
                {
                    UserId = command.UserId,
                    Text = command.Text,
                    CreatedAt = DateTime.Now,
                    TypeId = (int)PostTypeEnum.Post
                };
            }
        }
    }
}
