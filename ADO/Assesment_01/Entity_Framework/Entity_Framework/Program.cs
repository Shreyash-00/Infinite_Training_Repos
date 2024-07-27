using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    class Program
    {
        //let us create an object of the context class
        static infiniteDBEntities db = new infiniteDBEntities();
        static void Main(string[] args)
        {
            var emp = db.EMPs.ToList();

            foreach (var e in emp)
            {
                Console.WriteLine(e.EMPNO + " " + e.ENAME + " " + e.SAL);
            }

            Console.Read();
        }
    }
}

