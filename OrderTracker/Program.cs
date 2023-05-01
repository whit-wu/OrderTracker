using System;
using CsvHelper;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderTracker.Data;
using OrderTracker.Data.Migrations;
using System.Collections.Generic;
using OrderTracker.Model;

namespace OrderTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<OrderTrackerContext>();
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


                SeedData(dbContext);


            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void SeedData(OrderTrackerContext orderTrackerContext)
        {
            using (var reader = new StreamReader("../OrderTracker.Data/DataSourceCSVs/CustomerSeedAtStartup.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CustomerCsvDto>();

                List<Customer> customers = new List<Customer>();

                foreach (var record in records)
                {
                    customers.Add(new Customer
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        StreetAddress = record.StreetAddress,
                        City = record.City,
                        State = record.State,
                        ZIP = record.ZIP,
                        PhoneNumber = record.PhoneNumber,
                        Email = record.Email
                    });
                }

                orderTrackerContext.AddRange(customers);
                orderTrackerContext.SaveChanges();
            }
        }
    }
}
