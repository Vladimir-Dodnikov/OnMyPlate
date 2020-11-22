namespace OnMyPlate.Data.Models
{
    using System.Collections.Generic;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class Music : BaseDeletableModel<int>
    {
        public Music()
        {
            this.Places = new HashSet<Place>();
        }

        public MusicType MusicType { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
