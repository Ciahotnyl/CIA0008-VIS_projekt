﻿using Shift.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Domain
{
    public class EmployeeData
    {
        public static DatabaseTable<Employees> getEmployees()
        {
            DatabaseTable<Employees> employee = new DatabaseTable<Employees>();
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                employee.Fill(conn);
            }

            return employee;
        }
    }
}