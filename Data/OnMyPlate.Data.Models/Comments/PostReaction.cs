namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments.Enums;

    public class PostReaction : BaseDeletableModel<int>
    {
        public ReactionType ReactionType { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
