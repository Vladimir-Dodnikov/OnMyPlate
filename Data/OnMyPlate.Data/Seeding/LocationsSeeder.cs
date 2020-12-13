namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class LocationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Locations.Any())
            {
                return;
            }

            var locations = new List<Location>();
            using (StreamReader r = new StreamReader(@"Locations.json"))
            {
                string json = r.ReadToEnd();
                locations = JsonConvert.DeserializeObject<List<Location>>(json);
            }

            foreach (var location in locations)
            {
                await dbContext.Locations.AddAsync(location);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
