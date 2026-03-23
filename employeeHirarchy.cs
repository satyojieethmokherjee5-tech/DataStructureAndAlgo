using System;
using System.Collections.Generic;
using System.Linq;

					
public class Program
{
	public static void Main()
	{
		var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", ManagerId = null },
            new Employee { Id = 2, Name = "Bob", ManagerId = 1 },
            new Employee { Id = 3, Name = "Charlie", ManagerId = 1 },
            new Employee { Id = 4, Name = "David", ManagerId = 2 },
            new Employee { Id = 5, Name = "Eva", ManagerId = 2 }
        };

        var hierarchy = BuildHierarchy(employees);
        PrintHierarchy(hierarchy);

			
	}
	
	public static void PrintHierarchy(List<Employee> employees, int indent = 0)
{
    foreach (var emp in employees)
    {
        Console.WriteLine(new string(' ', indent * 2) + emp.Name);
        PrintHierarchy(emp.Reports, indent + 1);
    }
}
	
	public static List<Employee> BuildHierarchy(List<Employee> employees)
	{
    var lookup = employees.ToDictionary(e => e.Id);

    List<Employee> roots = new List<Employee>();

    foreach (var emp in employees)
    {
        if (emp.ManagerId.HasValue)
        {
            lookup[emp.ManagerId.Value].Reports.Add(emp);
        }
        else
        {
            roots.Add(emp); // Top-level employees (no manager)
        }
    }

    return roots;
	}
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ManagerId { get; set; }
    public List<Employee> Reports { get; set; } = new List<Employee>();
}




