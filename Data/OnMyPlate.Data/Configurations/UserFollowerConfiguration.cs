namespace OnMyPlate.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using OnMyPlate.Data.Models.Comments;

    public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> userFollower)
        {
            userFollower
                .HasKey(uf => new { uf.UserId, uf.FollowerId });

            userFollower
                .HasOne(uf => uf.User)
                .WithMany(u => u.Followers)
                .OnDelete(DeleteBehavior.Restrict);

            userFollower
                .HasOne(uf => uf.Follower)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            userFollower
                .HasIndex(uf => uf.IsDeleted);
        }
    }
}
