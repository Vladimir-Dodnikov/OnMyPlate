namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class PostReport : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.PostReportDescriptionMaxLength)]
        public string Description { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
