using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Models
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetConnectionString("EventDbCon");
        }
    }
}
