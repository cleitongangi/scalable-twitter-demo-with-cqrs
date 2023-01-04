namespace TwitterDemo.Domain.Models
{
    public class UserSummaryEntity
    {
        public long UserId { get; set; } // user_id (Primary key)        
        public int FollowersCount { get; set; } // followers_count
        public int FollowingCount { get; set; } // following_count
        public int PostsCount { get; set; } // posts_count
        public DateTime UpdatedAt { get; set; } // updated_at

        // Reverse navigation

        /// <summary>
        /// Child Posts where user.id point to this entity (fk_user_summary_user)
        /// </summary>
        public virtual UserAccountEntity User { get; set; } = null!; // user.fk_user_summary_user
    }
}
