﻿namespace OnMyPlate.Data.Models.Comments
{
    using System.Collections.Generic;

    using OnMyPlate.Data.Common.Models;

    public class Reply : BaseDeletableModel<int>
    {
        public Reply()
        {
            this.Reports = new HashSet<ReplyReport>();
            this.Reactions = new HashSet<ReplyReaction>();
        }

        public string Description { get; set; }

        public bool IsBestAnswer { get; set; }

        public int? ParentId { get; set; }

        public Reply Parent { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual ICollection<ReplyReport> Reports { get; set; }

        public virtual ICollection<ReplyReaction> Reactions { get; set; }
    }
}
