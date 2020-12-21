namespace OnMyPlate.Web.ViewModels.Places
{
    using System;

    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Services.Mapping;

    public class WorkTimeViewModel : IMapFrom<WorkTime>
    {
        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public int PlaceId { get; set; }
    }
}
