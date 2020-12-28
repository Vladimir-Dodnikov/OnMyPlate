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
    using OnMyPlate.Data.Models.Places;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Posts = new HashSet<Post>();
            this.Replies = new HashSet<Reply>();
            this.Votes = new HashSet<Vote>();

            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        [Required]
        [MaxLength(GlobalConstants.UserFirtNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CityMaxLength)]
        public string City { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public int Points { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<LogoImage> LogoImages { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
