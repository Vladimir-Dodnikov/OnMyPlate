namespace OnMyPlate.Services.Models
{
    using System;
    using System.Collections.Generic;

    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Data.Models.Places;

    public class PlaceDto
    {
        public PlaceDto()
        {
            this.Images = new List<Image>();
            this.Amentities = new List<Amentity>();
            this.Cuisines = new List<Cuisine>();
            this.PaymentTypes = new List<Payment>();
            this.MusicTypes = new List<Music>();
            this.Posts = new List<Post>();

            this.Location = new Location();
            this.Address = new Address();
            this.WorkTime = new WorkTime();

            this.Author = new ApplicationUser();
        }

        // Place
        public string PlaceName { get; set; }

        public string PlaceDescription { get; set; }

        public string LogoImage { get; set; }

        public string WebUrl { get; set; }

        public ApplicationUser Author { get; set; }

        public Location Location { get; set; }

        public Address Address { get; set; }

        public WorkTime WorkTime { get; set; }

        // Collections
        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Amentity> Amentities { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }

        public virtual ICollection<Payment> PaymentTypes { get; set; }

        public virtual ICollection<Music> MusicTypes { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
