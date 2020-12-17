namespace OnMyPlate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Data.Models.Places;

    public class Place : BaseDeletableModel<int>
    {
        public Place()
        {
            this.Cuisines = new HashSet<Cuisine>();
            this.Posts = new HashSet<Post>();
            this.Images = new HashSet<Image>();
            this.LogoImages = new HashSet<LogoImage>();
            this.MusicTypes = new HashSet<Music>();
        }

        [Required]
        [MaxLength(GlobalConstants.PlaceNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlaceDescriptionMaxLength)]
        public string Description { get; set; }

        public int Rating { get; set; }

        public int VisitsCount { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        public string WebUrl { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public WorkTime WorkTime { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<LogoImage> LogoImages { get; set; }

        public virtual ICollection<Amentity> Amentities { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }

        public virtual ICollection<Payment> PaymentTypes { get; set; }

        public virtual ICollection<Music> MusicTypes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
