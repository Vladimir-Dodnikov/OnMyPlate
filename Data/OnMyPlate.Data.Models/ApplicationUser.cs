// ReSharper disable VirtualMemberCallInConstructor
namespace OnMyPlate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Data.Models.Comments.Enums;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.SentMessages = new HashSet<Message>();
            this.ReceivedMessages = new HashSet<Message>();
            this.Posts = new HashSet<Post>();
            this.Replies = new HashSet<Reply>();

            this.PostReactions = new HashSet<PostReaction>();
            this.PostReports = new HashSet<PostReport>();
            this.ReplyReactions = new HashSet<ReplyReaction>();
            this.ReplyReports = new HashSet<ReplyReport>();

            this.Followers = new HashSet<UserFollower>();

            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        public GenderType Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public int Points { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserBiographyMaxLength)]
        public string Biography { get; set; }

        [Required]
        public string ProfilePicture { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<PostReaction> PostReactions { get; set; }

        public virtual ICollection<PostReport> PostReports { get; set; }

        public virtual ICollection<ReplyReaction> ReplyReactions { get; set; }

        public virtual ICollection<ReplyReport> ReplyReports { get; set; }

        public virtual ICollection<UserFollower> Followers { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
