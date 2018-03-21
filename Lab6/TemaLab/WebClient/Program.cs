using System;


namespace WebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeService myWebService = new EmployeeService();
            Console.WriteLine("2 + 3 = {0}", myWebService.add(2, 3));

            myWebService.getEmployee(2);
        }
    }
}
