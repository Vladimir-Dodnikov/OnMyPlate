namespace OnMyPlate.Data.Models.Comments
{
    using System.Collections.Generic;

    using OnMyPlate.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Posts = new HashSet<PostTag>();
        }

        public string Name { get; set; }

        public virtual ICollection<PostTag> Posts { get; set; }
    }
}
