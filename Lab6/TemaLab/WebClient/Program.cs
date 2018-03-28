using System;
using WebClient.localhost;
namespace WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.CookieContainer = new System.Net.CookieContainer();


            Employee smth1 = employeeService.createEmployee("mircea dobreanu", "123123");
            Employee smth2 = employeeService.createEmployee("barack obama", "374365643");
            Employee smth3 = employeeService.createEmployee("madonna", "541343");


            employeeService.addManager(smth1);
            employeeService.addEmployee(smth1, smth2);
            Console.WriteLine("Last edge was cycle: " + employeeService.wasCycle());

            //Employee[] empx = employeeService.getAllEmployees();
            employeeService.addEmployee(smth2, smth1);
            Console.WriteLine("Last edge was cycle: " + employeeService.wasCycle());

            employeeService.addEmployee(smth1, smth3);
            Console.WriteLine("Last edge was cycle: " + employeeService.wasCycle());

            employeeService.addEmployee(smth2, smth3);
            Console.WriteLine("Last edge was cycle: " + employeeService.wasCycle());

            employeeService.addEmployee(smth3, smth1);
            Console.WriteLine("Last edge was cycle: " + employeeService.wasCycle());


            Employee[] emp = employeeService.getAllEmployees();
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.id + " " + e.name);
            }
        }
    }
}
