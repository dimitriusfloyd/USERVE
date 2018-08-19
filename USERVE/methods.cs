using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace USERVE
{
    class Methods
    {
        static void NewRestaurant(string Name, string Address)
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
                cmd.CommandText = "INSERT INTO restaurants (Name, Address) VALUES (@Name, @Address);";
                cmd.Parameters.AddWithValue("Name", Name);
                cmd.Parameters.AddWithValue("Address", Address);

                cmd.ExecuteNonQuery();
            }

        }

        static void AddNewShelter(string Name, string Address, int Capacity)
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
                cmd.CommandText = "INSERT INTO shelters (Name, Address, Capacity) VALUES (@Name, @Address, @Capacity);";
                cmd.Parameters.AddWithValue("Name", Name);
                cmd.Parameters.AddWithValue("Address", Address);

                cmd.ExecuteNonQuery();
            }

        }

        static void AddNewTrasporter(string name, string vehicle, int driversliscense)
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
                cmd.CommandText = "INSERT INTO categories (name, vehicle, driversliscense) VALUES (@name, @vehicle, @driversliscense);";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("vehicle", vehicle);
                cmd.Parameters.AddWithValue("driversliscense", driversliscense);

                cmd.ExecuteNonQuery();
            }

        }
    }
}
