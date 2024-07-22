using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    private static string connectionString = "Server=ICS-LT-JN27893;Database=Assignment_02;Integrated Security=True;";
    private static SqlConnection con;
    private static SqlCommand cmd;
    private static SqlDataReader dr;

    static void Main(string[] args)
    {
        try
        {
            UpdateData();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            if (dr != null)
                dr.Close();
            if (con != null && con.State == ConnectionState.Open)
                con.Close();
        }

        Console.ReadLine();
    }

    private static SqlConnection getConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static void UpdateData()
    {
        using (con = getConnection())
        {
            con.Open();
            int empno;
            int newSalary;

            Console.WriteLine("\nEnter EMPNO to update salary:");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new SAL value: ");
            newSalary = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("UPDATE [Assignment_02].[dbo].[EMP] SET SAL = @newSalary WHERE EMPNO = @empno", con);
            cmd.Parameters.AddWithValue("@newSalary", newSalary);
            cmd.Parameters.AddWithValue("@empno", empno);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine("Update successful");
            else
                Console.WriteLine("No records updated");
        }
    }
}
