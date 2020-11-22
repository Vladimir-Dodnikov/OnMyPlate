using OnMyPlate.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMyPlate.Data.Models
{
    public class Seat : BaseDeletableModel<int>
    {
        public int Indoor { get; set; }

        public int Outdoor { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
