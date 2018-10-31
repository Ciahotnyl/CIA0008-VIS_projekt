using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS_projekt.Data;

namespace VIS_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseTable<Employee> employee = new DatabaseTable<Employee>();
            employee.Fill();
            Console.WriteLine(employee.TableName);
            foreach(var rec in employee)
            {
                Console.WriteLine(rec);
            }
            Console.ReadLine();
        }
    }
}
