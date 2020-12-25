namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Places;
    using OnMyPlate.Data.Models;

    public class WorkTimesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.WorkTimes.Any())
            {
                return;
            }

            var workTimes = new List<WorkTime>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\WorkTimes.json"))
            {
                string json = r.ReadToEnd();
                workTimes = JsonConvert.DeserializeObject<List<WorkTime>>(json);
            }

            foreach (var workTime in workTimes)
            {
                await dbContext.WorkTimes.AddAsync(workTime);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
