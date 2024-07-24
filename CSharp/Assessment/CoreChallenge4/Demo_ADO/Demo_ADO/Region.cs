using System;
using System.Data.SqlClient;

namespace Demo_ADO
{
    public class DataAccess
    {
        private static string connectionString = "data source = ICS-LT-JN27893; initial catalog = North_wind; integrated security = true;";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        public static string InsertRegion(int rid, string rdesc)
        {
            string result = "Failed";
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Region (RegionID, RegionDescription) VALUES (@rid, @rdesc)", con))
                    {
                        cmd.Parameters.AddWithValue("@rid", rid);
                        cmd.Parameters.AddWithValue("@rdesc", rdesc);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        result = rowsAffected > 0 ? "Data inserted successfully." : "Data insertion failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                result = "Error: " + ex.Message;
            }
            return result;
        }

        public static SqlDataReader DisplayRegion()
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Region", con);
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); // Ensure connection is closed when reader is closed
        }
    }

    public class Region
    {
        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public string InsertRegion()
        {
            Console.WriteLine("Enter Region ID:");
            RegionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Region Description:");
            RegionDescription = Console.ReadLine();
            return DataAccess.InsertRegion(RegionId, RegionDescription);
        }

        public SqlDataReader DisplayRegion()
        {
            return DataAccess.DisplayRegion();
        }
    }

    class Client
    {
        static void Main()
        {
            Region region = new Region();

            // Display existing regions
            Console.WriteLine("Existing Regions:");
            using (SqlDataReader reader = region.DisplayRegion())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RegionID"]}, {reader["RegionDescription"]}");
                }
            }

            // Insert new region
            Console.WriteLine("\nInserting a new region...");
            string result = region.InsertRegion();
            Console.WriteLine(result); // Print the result of the insertion

            // Display updated list of regions
            Console.WriteLine("\nUpdated list of regions:");
            using (SqlDataReader reader = region.DisplayRegion()) // Retrieve updated data
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RegionID"]}, {reader["RegionDescription"]}");
                }
            }

            Console.ReadLine(); 
        }
    }
}
