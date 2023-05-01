using CsvHelper;
using System.Globalization;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;

namespace OrderTracker.Data.Migrations
{
    public partial class SeedViaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var reader = new StreamReader("../OrderTracker.Data/DataSourceCSVs/CustomerSeedViaMigration.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CustomerCsvDto>();

                foreach (var record in records)
                {
                    migrationBuilder.InsertData(
                        table: "Customers",
                        columns: new[] {
                           "FirstName",
                           "LastName",
                           "StreetAddress",
                            "City",
                            "State",
                            "ZIP",
                            "PhoneNumber",
                            "Email"
                             },
                        
                       
                        values: new object[] {
                            record.FirstName,
                            record.LastName,
                            record.StreetAddress,
                            record.City,
                            record.State,
                            record.ZIP,
                            record.PhoneNumber,
                            record.Email
                             }
                        );
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }

    public class CustomerCsvDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIP { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
