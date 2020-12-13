namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models;
    using OnMyPlate.Data.Models.Places;

    public class PlacesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Places.Any())
            {
                return;
            }

            var places = new List<Place>();
            using (StreamReader r = new StreamReader(@"Places.json"))
            {
                string json = r.ReadToEnd();
                places = JsonConvert.DeserializeObject<List<Place>>(json);
            }

            foreach (var place in places)
            {
                await dbContext.Places.AddAsync(place);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
