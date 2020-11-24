namespace OnMyPlate.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}
