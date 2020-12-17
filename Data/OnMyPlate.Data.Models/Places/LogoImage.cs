namespace OnMyPlate.Data.Models.Places
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    using OnMyPlate.Data.Common.Models;

    public class LogoImage : BaseModel<string>
    {
        public LogoImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PlaceId { get; set; }

        public Place Place { get; set; }

        public string Extension { get; set; }

        //// The contents of the image is in the file system

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
