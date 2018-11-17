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
            //******************Employees*******************
            DatabaseTable<Employees> employee = new DatabaseTable<Employees>();
            employee.Fill();
            Console.WriteLine(employee.TableName);
            foreach(var rec in employee)
            {
                Console.WriteLine(rec);
            }
            //******************Employees*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************Reasons*******************
            DatabaseTable<Reasons> reason = new DatabaseTable<Reasons>();
            reason.Fill();
            Console.WriteLine(reason.TableName);
            foreach (var rec in reason)
            {
                Console.WriteLine(rec);
            }
            //******************Reasons*******************            
            Console.WriteLine("---------------------------------------------------------------");
            //******************Absences*******************
            DatabaseTable<Absences> absence = new DatabaseTable<Absences>();
            absence.Fill();
            Console.WriteLine(absence.TableName);
            foreach (var rec in absence)
            {
                Console.WriteLine(rec);
            }
            //******************Absences*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************Positions*******************
            DatabaseTable<Positions> position = new DatabaseTable<Positions>();
            position.Fill();
            Console.WriteLine(position.TableName);
            foreach (var rec in position)
            {
                Console.WriteLine(rec);
            }
            //******************Positions*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************EmployeePosition*******************
            DatabaseTable<EmployeePosition> emp_pos = new DatabaseTable<EmployeePosition>();
            emp_pos.Fill();
            Console.WriteLine(emp_pos.TableName);
            foreach (var rec in emp_pos)
            {
                Console.WriteLine(rec);
            }
            //******************EmployeePosition*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************Workplaces*******************
            DatabaseTable<Workplaces> workplace = new DatabaseTable<Workplaces>();
            workplace.Fill();
            Console.WriteLine(workplace.TableName);
            foreach (var rec in workplace)
            {
                Console.WriteLine(rec);
            }
            //******************Workplaces*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************Teams*******************
            DatabaseTable<Teams> team = new DatabaseTable<Teams>();
            team.Fill();
            Console.WriteLine(team.TableName);
            foreach (var rec in team)
            {
                Console.WriteLine(rec);
            }
            //******************Teams*******************
            Console.WriteLine("---------------------------------------------------------------");
            //******************TeamShift*******************
            DatabaseTable<TeamShift> team_shift = new DatabaseTable<TeamShift>();
            team_shift.Fill();
            Console.WriteLine(team_shift.TableName);
            foreach (var rec in team_shift)
            {
                Console.WriteLine(rec);
            }
            //******************Teams*******************
            Console.ReadLine();
        }
    }
}
