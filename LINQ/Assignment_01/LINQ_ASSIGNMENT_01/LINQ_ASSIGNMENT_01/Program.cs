using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ASSIGNMENT_01
{

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {


            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            Console.WriteLine("-----------------------------QUERY 1----------------------------------------");
            // 1. Show all employees who joined before 1/1/2015
            var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before January 1, 2015:");
            foreach (var employee in joinedBefore2015)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }


            Console.WriteLine("-----------------------------QUERY 2----------------------------------------");


            // 2. Show all employees whose date of birth is after 1/1/1990
            var dobAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees born after January 1, 1990:");
            foreach (var employee in dobAfter1990)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }

            Console.WriteLine("-----------------------------QUERY 3----------------------------------------");
            // 3. Show all employees who are either Consultants or Associates
            var consultantsAndAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("\nEmployees who are Consultants or Associates:");
            foreach (var employee in consultantsAndAssociates)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine("-----------------------------QUERY 4----------------------------------------");
            // 4. Show total number of employees
            int totalEmployees = empList.Count;
            Console.WriteLine($"\nTotal number of employees: {totalEmployees}");
            Console.WriteLine("-----------------------------QUERY 5----------------------------------------");
            // 5. Show total number of employees in Chennai
            int chennaiEmployees = empList.Count(e => e.City == "Chennai");
            Console.WriteLine($"Number of employees in Chennai: {chennaiEmployees}");
            Console.WriteLine("-----------------------------QUERY 6----------------------------------------");
            // 6. Show the highest employee ID
            int highestEmployeeID = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"Highest employee ID: {highestEmployeeID}");
            Console.WriteLine("-----------------------------QUERY 7----------------------------------------");
            // 7. Show total number of employees who joined after 1/1/2015
            int joinedAfter2015 = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Number of employees who joined after January 1, 2015: {joinedAfter2015}");
            Console.WriteLine("-----------------------------QUERY 8----------------------------------------");
            // 8. Show total number of employees whose title is not "Associate"
            int notAssociateEmployees = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"Number of employees who are not Associates: {notAssociateEmployees}");
            Console.WriteLine("-----------------------------QUERY 9----------------------------------------");
            // 9. Show the number of employees in each city
            var employeesByCity = empList.GroupBy(e => e.City);
            Console.WriteLine("\nNumber of employees by city:");
            foreach (var group in employeesByCity)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
            Console.WriteLine("-----------------------------QUERY 10----------------------------------------");
            // 10. Show the number of employees by city and title
            var employeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title });
            Console.WriteLine("\nNumber of employees by city and title:");
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"{group.Key.City} - {group.Key.Title}: {group.Count()}");
            }
            Console.WriteLine("-----------------------------QUERY 11----------------------------------------");
            // 11. Show the youngest employee
            var youngestEmployee = empList.OrderBy(e => e.DOB).First();
            Console.WriteLine($"\nThe youngest employee is: {youngestEmployee.FirstName} {youngestEmployee.LastName}");

            Console.ReadLine();


        }
    }


}
