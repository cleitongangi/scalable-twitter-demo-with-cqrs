namespace TwitterDemo.Domain.Models
{
    public class UserFollowingEntity
    {
        public long Id { get; set; } // id (Primary key)
        public long UserId { get; set; } // user_id
        public long TargetUserId { get; set; } // target_user_id
        public DateTime CreatedAt { get; set; } // created_at
        public bool Active { get; set; } // active
        public DateTime? RemovedAt { get; set; } // removed_at
    }
}
