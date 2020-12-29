namespace OnMyPlate.Services.Data.Comments
{
    using System;
    using System.Threading.Tasks;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Comments;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<Post> postsRepository)
        {
            this.placesRepository = placesRepository;
            this.postsRepository = postsRepository;
        }

        public async Task<int> CreateAsync(string postDescription, DateTime date, string authorId, int placeId)
        {
            var post = new Post
            {
                PostDescription = postDescription,
                Date = date,
                AuthorId = authorId,
                PlaceId = placeId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return post.Id;
        }
    }
}
