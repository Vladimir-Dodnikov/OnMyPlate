namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models.Places;

    public class PaymentsService : IPaymentsService
    {
        private readonly IDeletableEntityRepository<Payment> payments;

        public PaymentsService(IDeletableEntityRepository<Payment> payments)
        {
            this.payments = payments;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllPaymentTypesAsKeyValuePairs()
        {
            return this.payments.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .GroupBy(x => x.Name)
            .Select(x => x.First())
            .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), s.Name));
        }

        public int GetCounts()
        {
            return this.payments.All().ToList().GroupBy(x => x.Name).Select(x => x.First()).Count();
        }
    }
}
