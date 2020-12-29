namespace OnMyPlate.Services.Data.Comments
{
    using System;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreateAsync(string postDescription, DateTime date, string authorId, int placeId);
    }
}
