namespace OnMyPlate.Data.Models
{
    using System.Collections.Generic;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class Place : BaseDeletableModel<int>
    {
        public Place()
        {
            this.Seats = new HashSet<Seat>();
            this.Cuisines = new HashSet<Cuisine>();
            this.MusicGenres = new HashSet<Music>();
            this.PlaceTypes = new HashSet<PlaceType>();
        }

        public string Name { get; set; }

        public int Rating { get; set; }

        public int VisitsCount { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public string PhoneNumber { get; set; }

        public string WebUrl { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }

        public virtual ICollection<Music> MusicGenres { get; set; }

        public virtual ICollection<PlaceType> PlaceTypes { get; set; }

        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
