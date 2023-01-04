namespace TwitterDemo.Domain.Models
{
    public class UserAccountEntity
    {
        public long Id { get; set; } // id (Primary key)
        public string Username { get; set; } = null!; // username (length: 14)
        public DateTime JoinedAt { get; set; } // joined_at
        
        // Reverse navigation

        /// <summary>
        /// Child Posts where posts.user_id point to this entity (fk_posts_user)
        /// </summary>
        public virtual ICollection<PostEntity> Posts { get; set; } // posts.fk_posts_user

        /// <summary>
        /// Related UserSummary where user_summary.user_id point to this entity (fk_user_summary_user)
        /// </summary>
        public virtual UserSummaryEntity UserSummary { get; set; } = null!; // user_summary

        public UserAccountEntity()
        {
            Posts = new List<PostEntity>();
        }
    }
}
