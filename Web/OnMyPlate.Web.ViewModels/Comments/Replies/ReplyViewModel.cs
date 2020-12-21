namespace OnMyPlate.Web.ViewModels.Comments.Replies
{
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;
    using OnMyPlate.Common;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Services.Mapping;

    public class ReplyViewModel : IMapFrom<Reply>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string ReplyDescription { get; set; }

        public string SanitizedReplyDescription => new HtmlSanitizer().Sanitize(this.ReplyDescription);

        public bool IsBestAnswer { get; set; }

        public int ParentId { get; set; }

        public int PostId { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}
