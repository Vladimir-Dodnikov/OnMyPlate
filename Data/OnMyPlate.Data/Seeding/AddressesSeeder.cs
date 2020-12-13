namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class AddressesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Addresses.Any())
            {
                return;
            }

            var addresses = new List<Address>();
            using (StreamReader r = new StreamReader(@"Addresses.json"))
            {
                string json = r.ReadToEnd();
                addresses = JsonConvert.DeserializeObject<List<Address>>(json);
            }

            foreach (var address in addresses)
            {
                await dbContext.Addresses.AddAsync(address);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
