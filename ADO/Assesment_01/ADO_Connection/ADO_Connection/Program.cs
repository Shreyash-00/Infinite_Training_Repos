using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Connection
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            InsertEmpData();

            SelectEmpData();
            // Select_With_Parameters();

            Console.Read();
        }

        //let us create a common function to get the database connection
        private static SqlConnection getConnection()
        {
            con = new SqlConnection("data source = ICS-LT-JN27893; initial catalog = Employeemanagement" +
                ";" +
                "integrated security = true;");
            con.Open();
            return con;

        }

        public static void InsertEmpData()
        {
            con = getConnection();

            Console.WriteLine("Enter Employee Name:");
            string empName = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary:");
            decimal empSal = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter Employee Type:");
            char empType = Convert.ToChar(Console.ReadLine());

            cmd = new SqlCommand("AddEmp_Sp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@empname", empName);
            cmd.Parameters.AddWithValue("@empsal", empSal);
            cmd.Parameters.AddWithValue("@emptype", empType);

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
                Console.WriteLine("Insertion success");
            else
                Console.WriteLine("Could not insert data");
            con.Close();
        }

        public static void SelectEmpData()
        {
            con = getConnection();
            SqlCommand cmd1 = new SqlCommand("select * from Employee_Details", con);
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Empno : {0},EmpName : {1},EmpSal : {2},EmpType : {3}",
                dr["Empno"], dr["EmpName"], dr["EmpSal"], dr["EmpType"]);
            }

            con.Close();

        }

    }






}