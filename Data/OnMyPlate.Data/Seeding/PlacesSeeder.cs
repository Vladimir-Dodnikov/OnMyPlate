namespace OnMyPlate.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
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

            string sqlConnectionString = @"Server=.;Database=OnMyPlate;Trusted_Connection=yes;MultipleActiveResultSets=true;Provider=SQLNCLI11.0";

            string script = "";
            using (StreamReader r = new StreamReader(@"..\..\Data\OnMyPlate.Data\Seeding\ImportData\CreateOnMyPlateDB.txt"))
            {
                script = r.ReadToEnd();
            }

            OleDbConnection connection = new OleDbConnection(sqlConnectionString);
            connection.Open();
            OleDbCommand sqlCommand = new OleDbCommand(script, connection);
            sqlCommand.CommandTimeout = 10800;
            sqlCommand.ExecuteNonQuery();
        }
    }
}
