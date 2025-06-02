using System;
using ABC_TechSolutions.dao;
using ABC_TechSolutions.model;

class Program
{
    static void Main(string[] args)
    {
        // a. Create Part Time Employee
        Employee emp1 = new Employee
        {
            EmpCode = 100,
            EmpName = "Scott",
            Email = "scott@gmail.com",
            DeptName = "ODC",
            Location = "Pune"
        };

        PartTimeEmployee pte = new PartTimeEmployee
        {
            Basic = 10000 
        };
        pte.CalculateSalary();
        Console.WriteLine($"{emp1.EmpCode}\t{emp1.EmpName}\t{emp1.Email}\t{emp1.DeptName}\t{emp1.Location}");
        Console.WriteLine($"Net Salary For Part Time Employee is:{pte.NetSalary}");

        // b. Create Full Time Employee
        Employee emp2 = new Employee
        {
            EmpCode = 101,
            EmpName = "Tiger",
            Email = "tiger@gmail.com",
            DeptName = "Hr",
            Location = "Pune"
        };

        FullTimeEmployee fte = new FullTimeEmployee
        {
            Basic = 20000 
        };
        fte.CalculateSalary();
        Console.WriteLine($"{emp2.EmpCode}\t{emp2.EmpName}\t{emp2.Email}\t{emp2.DeptName}\t{emp2.Location}");
        Console.WriteLine($"Net Salary For Full Time Employee is:{fte.NetSalary}");

        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey();
    }
}
