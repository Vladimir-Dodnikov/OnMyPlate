namespace OnMyPlate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;

    public class Cuisine : BaseDeletableModel<int>
    {
        public Cuisine()
        {
            this.Places = new HashSet<Place>();
        }

        public CuisineType CuisineType { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
