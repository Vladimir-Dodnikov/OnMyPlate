namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class PaymentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Payments.Any())
            {
                return;
            }

            var payments = new List<Payment>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Payments.json"))
            {
                string json = r.ReadToEnd();
                payments = JsonConvert.DeserializeObject<List<Payment>>(json);
            }

            foreach (var payment in payments)
            {
                await dbContext.Payments.AddAsync(payment);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
