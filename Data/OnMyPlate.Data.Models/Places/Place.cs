namespace OnMyPlate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class Place : BaseDeletableModel<int>
    {
        public Place()
        {
            this.Seats = new HashSet<Seat>();
            this.Cuisines = new HashSet<Cuisine>();
            this.MusicGenres = new HashSet<Music>();
            this.PlaceTypes = new HashSet<PlaceCategory>();
            this.Posts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(GlobalConstants.PlaceNameMaxLength)]
        public string Name { get; set; }

        public int Rating { get; set; }

        public int VisitsCount { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string PhoneNumber { get; set; }

        public string WebUrl { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlaceDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }

        public virtual ICollection<Music> MusicGenres { get; set; }

        public virtual ICollection<PlaceCategory> PlaceTypes { get; set; }

        public virtual ICollection<Payment> PaymentTypes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
