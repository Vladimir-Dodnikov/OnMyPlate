namespace OnMyPlate.Data.Models.Comments
{
    using OnMyPlate.Data.Common.Models;

    public class ReplyReport : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int ReplyId { get; set; }

        public virtual Reply Reply { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
