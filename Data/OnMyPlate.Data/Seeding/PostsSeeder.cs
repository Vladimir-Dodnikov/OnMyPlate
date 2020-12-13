namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using OnMyPlate.Data.Models.Comments;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            JsonSerializer serializer = new JsonSerializer();
            var posts = new List<Post>();
            using (FileStream s = File.Open(@"Posts.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        posts = serializer.Deserialize<List<Post>>(reader);
                    }
                }
            }

            foreach (var post in posts)
            {
                await dbContext.Posts.AddAsync(post);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
