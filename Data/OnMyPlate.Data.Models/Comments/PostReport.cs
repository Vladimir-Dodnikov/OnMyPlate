namespace OnMyPlate.Data.Models.Comments
{
    using OnMyPlate.Data.Common.Models;

    public class PostReport : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
