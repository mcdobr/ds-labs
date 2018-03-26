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


            Employee ex = employeeService.hireEmployee("mircea dobreanu", "123123");
            employeeService.hireEmployee("barack obama", "374365643");
            employeeService.hireEmployee("madonna", "541343");
            
            

            Employee[] emp = employeeService.getAllEmployees();
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.id + " " + e.name);
            }
        }
    }
}
