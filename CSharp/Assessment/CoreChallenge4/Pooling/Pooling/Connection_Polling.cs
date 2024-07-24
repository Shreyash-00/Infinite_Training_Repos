using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Pooling
{
    class Connection_Polling
    {
        public static string connectstr = "data source = ICS-LT-JN27893; initial catalog = North_wind;" +
                  "integrated security = true;Pooling = true";

        public static void Main()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                SqlConnection con = new SqlConnection(connectstr);
                con.Open();
                con.Close();
            }
            stopwatch.Stop();
            Console.WriteLine($"Time Taken : {stopwatch.ElapsedMilliseconds} ms");
            Transaction_Eg(connectstr);
            Console.Read();
        }

        //transaction example
        public static void Transaction_Eg(string str)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();  // an sqlcommand object is returnded
                SqlTransaction tran;

                tran = con.BeginTransaction();  //associating  the transaction object to the connection
                cmd.Transaction = tran;
                try
                {
                    cmd.CommandText = "Insert into Region values(102, 'New Region')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update Region set regiondescription = 'SouthEasternWestern' where regionid = 4";
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("2 Transaction successful");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Something went wrong in transaction...try later");
                    try
                    {
                        tran.Rollback();
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                }
            }

        }

    }
}
