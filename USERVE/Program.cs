using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace USERVE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void AddNewCategory(string newCategory)
        {

            IConfiguration configBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("appsettings.debug.json")
#else
                .AddJsonFile("appsettings.release.json")
#endif
                .Build();

            string connStr = configBuilder.GetConnectionString("DefaultConnection");

            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO categories (Name) VALUES (@newCategory)";
                cmd.Parameters.AddWithValue("newCategory", newCategory);

                cmd.ExecuteNonQuery();
            }

        }

    }
}
