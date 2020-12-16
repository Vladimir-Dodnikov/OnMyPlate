namespace OnMyPlate.Services
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AngleSharp;

    public class GatherRezzoIdsService
    {
        private static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync("https://rezzo.bg/en/sofia/search?h=all&limit=284");

            var wrap = document.QuerySelectorAll(".restaurant-wrapper > .rest-new > a");
            var path = "../../../ImportRezzoIds.txt";

            // Console.WriteLine(href);
            foreach (var item in wrap)
            {
                var href = item.GetAttribute("href");
                var regex = Regex.Match(href, @"[^\/en\/r\/v\/]\d+");

                File.AppendAllText(path, regex.ToString() + Environment.NewLine);
            }
        }
    }
}
