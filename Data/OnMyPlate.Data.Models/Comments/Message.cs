namespace OnMyPlate.Data.Models.Comments
{
    using OnMyPlate.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }
    }
}
