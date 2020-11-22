namespace OnMyPlate.Data.Models.Comments
{
    using OnMyPlate.Data.Common.Models;

    public class UserFollower : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string FollowerId { get; set; }

        public virtual ApplicationUser Follower { get; set; }
    }
}
