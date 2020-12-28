namespace OnMyPlate.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {

        Task SetVoteAsync(int placeId, string userId, byte value);

        double GetAverageVotes(int placeId);

        int GetCounts();
    }
}
