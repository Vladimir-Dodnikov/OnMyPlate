namespace OnMyPlate.Data.Models.Comments
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Replies = new HashSet<Reply>();
        }

        [Required]
        [MaxLength(GlobalConstants.MessageContentMaxLength)]
        public string PostDescription { get; set; }

        public DateTime Date { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
