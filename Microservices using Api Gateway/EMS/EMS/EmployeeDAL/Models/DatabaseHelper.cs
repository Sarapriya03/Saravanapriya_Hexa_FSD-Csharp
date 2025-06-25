using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

    //Microsoft.Extensions.Configuration
    //Microsoft.Extensions.Configuration.FileExtensions
    //Microsoft.Extensions.Configuration.Json


namespace EmployeeDAL.Models
{
    public class DatabaseHelper
    {
        public static string? GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            string? connectionString = builder.Build().GetConnectionString("EmpDbCon");
            return connectionString;
        }
    }
}
