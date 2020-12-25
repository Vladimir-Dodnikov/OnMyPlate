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

    public class AspNetUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var users = new List<ApplicationUser>();
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Users1.json"))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(json);
            }

            foreach (var user in users)
            {
                await dbContext.Users.AddAsync(user);
            }

            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Users2.json"))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(json);
            }

            foreach (var user in users)
            {
                await dbContext.Users.AddAsync(user);
            }

            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\Users3.json"))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<ApplicationUser>>(json);
            }

            foreach (var user in users)
            {
                await dbContext.Users.AddAsync(user);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
