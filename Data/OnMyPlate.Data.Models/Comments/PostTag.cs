namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostTag
    {
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
