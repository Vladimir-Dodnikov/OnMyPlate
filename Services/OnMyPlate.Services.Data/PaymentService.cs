namespace OnMyPlate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models.Places;

    public class PaymentService : IPaymentService
    {
        private readonly IDeletableEntityRepository<Payment> payments;

        public PaymentService(IDeletableEntityRepository<Payment> payments)
        {
            this.payments = payments;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAllPaymentTypesAsKeyValuePairs()
        {
            return this.payments.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .GroupBy(x => x.Name)
            .Select(x => x.First())
            .Select(s => new KeyValuePair<int, string>(s.Id, s.Name));
        }
    }
}
