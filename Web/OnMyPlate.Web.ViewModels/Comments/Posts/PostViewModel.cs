namespace OnMyPlate.Web.ViewModels.Comments.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;
    using OnMyPlate.Common;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Services.Mapping;
    using OnMyPlate.Web.ViewModels.Comments.Replies;
    using OnMyPlate.Web.ViewModels.Places;

    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string PostDescription { get; set; }

        public string SanitizedPostDescription => new HtmlSanitizer().Sanitize(this.PostDescription);

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public AuthorViewModel Author { get; set; }

        public int PlaceId { get; set; }

        public PlaceViewModel Place { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }
    }
}
