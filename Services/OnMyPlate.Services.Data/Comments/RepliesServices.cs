namespace OnMyPlate.Services.Data.Comments
{
    using System.Threading.Tasks;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Comments;

    public class RepliesServices : IRepliesService
    {
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;
        private readonly IDeletableEntityRepository<Reply> repliesRepository;

        public RepliesServices(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<Post> postsRepository,
            IDeletableEntityRepository<Reply> repliesRepository)
        {
            this.placesRepository = placesRepository;
            this.postsRepository = postsRepository;
            this.repliesRepository = repliesRepository;
        }

        public async Task CreateAsync(string description, int? parentId, int postId, string authorId)
        {
            var reply = new Reply
            {
                ReplyDescription = description,
                ParentId = parentId,
                PostId = postId,
                AuthorId = authorId,
            };

            await this.repliesRepository.AddAsync(reply);
            await this.repliesRepository.SaveChangesAsync();
        }
    }
}
