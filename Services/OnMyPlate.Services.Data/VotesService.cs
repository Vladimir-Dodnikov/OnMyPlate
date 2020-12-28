namespace OnMyPlate.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models.Places;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int placeId)
        {
            return this.votesRepository.All()
                .Where(x => x.PlaceId == placeId)
                .Average(x => x.Value);
        }

        public async Task SetVoteAsync(int placeId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.PlaceId == placeId && x.UserId == userId);
            if (vote == null)
            {
                vote = new Vote
                {
                    PlaceId = placeId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }

        public int GetCounts()
        {
            return this.votesRepository.All().Count();
        }
    }
}
