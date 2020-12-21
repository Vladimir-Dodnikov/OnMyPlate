namespace OnMyPlate.Web.ViewModels.Comments.Replies
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Models.Comments;
    using OnMyPlate.Services.Mapping;

    public class ReplyCreateInputModel : IMapFrom<Reply>
    {
        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string ReplyDescription { get; set; }

        public int ParentId { get; set; }

        public int PostId { get; set; }

        public string AuthorId { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}
