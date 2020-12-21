namespace OnMyPlate.Web.ViewModels.Comments.Posts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Services.Mapping;
    using OnMyPlate.Web.ViewModels.Places;

    public class PostCreateInputModel : IMapFrom<Post>
    {
        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string PostDescription { get; set; }

        public DateTime Date { get; set; }

        public int AuhtorId { get; set; }

        public AuthorViewModel Author { get; set; }

        public int PlaceId { get; set; }

        public PlaceViewModel Place { get; set; }
    }
}
