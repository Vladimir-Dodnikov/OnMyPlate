namespace OnMyPlate.Data.Models.Places
{
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Places.PlaceEnums;
    using System.Collections.Generic;

    public class Payment : BaseDeletableModel<int>
    {
        public Payment()
        {
            this.Places = new HashSet<Place>();
        }

        public PaymentType PaymentType { get; set; }

        public virtual ICollection<Place> Places { get; set; }
    }
}
