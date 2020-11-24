namespace OnMyPlate.Data.Models.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using OnMyPlate.Common;
    using OnMyPlate.Data.Common.Models;
    using OnMyPlate.Data.Models.Comments.Enums;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Replies = new HashSet<Reply>();
            this.Tags = new HashSet<PostTag>();
            this.Reactions = new HashSet<PostReaction>();
            this.Reports = new HashSet<PostReport>();
        }

        [Required]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; }

        public PostType Type { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PostDescriptionMaxLength)]
        public string Description { get; set; }

        public int Views { get; set; }

        public bool IsPinned { get; set; }

        [Required]
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        [ForeignKey(nameof(Place))]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public virtual ICollection<PostTag> Tags { get; set; }

        public virtual ICollection<PostReaction> Reactions { get; set; }

        public virtual ICollection<PostReport> Reports { get; set; }
    }
}
