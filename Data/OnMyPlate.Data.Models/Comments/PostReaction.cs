namespace OnMyPlate.Data.Models.Comments
{
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments.Enums;

    public class PostReaction : BaseDeletableModel<int>
    {
        public ReactionType ReactionType { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
