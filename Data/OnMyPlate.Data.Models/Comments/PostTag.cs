namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PostTag
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
