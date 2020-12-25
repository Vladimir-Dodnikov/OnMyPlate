namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;

    public class LogoImagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.LogoImages.Any())
            {
                return;
            }

            var logoImages = new List<LogoImage>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\LogoImages.json"))
            {
                string json = r.ReadToEnd();
                logoImages = JsonConvert.DeserializeObject<List<LogoImage>>(json);
            }

            foreach (var image in logoImages)
            {
                await dbContext.LogoImages.AddAsync(image);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
