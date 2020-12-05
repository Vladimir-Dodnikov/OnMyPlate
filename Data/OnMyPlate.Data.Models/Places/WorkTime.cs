namespace OnMyPlate.Data.Models.Places
{
    using System;

    using OnMyPlate.Data.Common.Models;

    public class WorkTime : BaseDeletableModel<int>
    {
        public string Day { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }
    }
}
