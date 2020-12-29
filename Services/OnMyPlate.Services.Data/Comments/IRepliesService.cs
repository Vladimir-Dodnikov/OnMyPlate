namespace OnMyPlate.Services.Data.Comments
{
    using System.Threading.Tasks;

    public interface IRepliesService
    {
        Task CreateAsync(string description, int? parentId, int postId, string authorId);
    }
}
