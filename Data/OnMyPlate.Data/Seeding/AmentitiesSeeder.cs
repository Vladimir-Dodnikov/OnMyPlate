namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class AmentitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Amentities.Any())
            {
                return;
            }

            var amentities = new List<Amentity>();
            using (StreamReader r = new StreamReader(@"Amentities.json"))
            {
                string json = r.ReadToEnd();
                amentities = JsonConvert.DeserializeObject<List<Amentity>>(json);
            }

            foreach (var amentity in amentities)
            {
                await dbContext.Amentities.AddAsync(amentity);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
