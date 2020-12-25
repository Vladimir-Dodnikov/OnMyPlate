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

    public class CuisinesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cuisines.Any())
            {
                return;
            }

            var cuisines = new List<Cuisine>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Cuisines.json"))
            {
                string json = r.ReadToEnd();
                cuisines = JsonConvert.DeserializeObject<List<Cuisine>>(json);
            }

            foreach (var cuisine in cuisines)
            {
                await dbContext.Cuisines.AddAsync(cuisine);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
