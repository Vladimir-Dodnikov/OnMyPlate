namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments.Enums;

    public class ReplyReaction : BaseDeletableModel<int>
    {
        public ReactionType ReactionType { get; set; }

        [Required]
        [ForeignKey(nameof(Reply))]
        public int ReplyId { get; set; }

        public virtual Reply Reply { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
