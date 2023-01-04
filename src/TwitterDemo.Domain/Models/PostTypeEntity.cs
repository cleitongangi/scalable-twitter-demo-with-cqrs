namespace TwitterDemo.Domain.Models
{
    public class PostTypeEntity
    {
        public int Id { get; set; } // id (Primary key)
        public string TypeDescription { get; set; } = null!; // type_description (length: 6)

        // Reverse navigation

        /// <summary>
        /// Child Posts where posts.type_id point to this entity (fk_posts_post_type)
        /// </summary>
        public virtual ICollection<PostEntity> Posts { get; set; } // posts.fk_posts_post_type

        public PostTypeEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
