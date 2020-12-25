namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class ImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Images.Any())
            {
                return;
            }

            var images = new List<Image>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Images.json"))
            {
                string json = r.ReadToEnd();
                images = JsonConvert.DeserializeObject<List<Image>>(json);
            }

            foreach (var image in images)
            {
                await dbContext.Images.AddAsync(image);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
