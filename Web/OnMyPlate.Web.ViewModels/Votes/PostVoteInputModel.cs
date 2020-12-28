namespace OnMyPlate.Web.ViewModels.Votes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostVoteInputModel
    {
        public int PlaceId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
