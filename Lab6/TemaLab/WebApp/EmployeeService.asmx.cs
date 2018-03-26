using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace WebApp
{
    /// <summary>
    /// Summary description for MyWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : WebService
    {
        public EmployeeService()
        {
            if (Session["employees"] == null)
                Session["employees"] = new List<Employee>();
        }
        
        // Required (trebuie sa transform employee in manager?)
        [WebMethod(EnableSession = true)]
        public void addManager(Employee e)
        {

        }

        // Required
        [WebMethod(EnableSession = true)]
        public void addEmployee(Employee manager, Employee employee)
        {
            // Trebuie sa caut circularitate
            if (!manager.Subordinates.Contains(employee))
                manager.Subordinates.Add(employee);
        }
        

        // Required
        [WebMethod(EnableSession = true)]
        public Employee getManagerOf(Employee employee)
        {
            return employee.Manager;
        }

        // Required
        [WebMethod(EnableSession = true)]
        public Employee[] getEmployeesOf(Employee manager)
        {
            return manager.Subordinates.ToArray();
        }


        [WebMethod(EnableSession = true)]
        public Employee[] getAllEmployees()
        {
            return ((List<Employee>)Session["employees"]).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public Employee hireEmployee(string name, string ssn)
        {
            Employee employee = createEmployee(name, ssn);
            ((List<Employee>)Session["employees"]).Add(employee);
            string str = employee.ToString();

            return employee;
        }

        [WebMethod]
        public Employee createEmployee(string name, string ssn)
        {
            return new Employee(Guid.NewGuid(), name, ssn);
        }
    }
    
    public class Employee
    {
        [XmlAttribute]
        public Guid id;
        public string name, ssn;

        private Employee manager;
        private List<Employee> subordinates;


        public Employee() { }

        public Employee(Guid id, string name, string ssn, Employee manager = null, List<Employee> subordinates = null)
        {
            this.id = id;
            this.name = name;
            this.ssn = ssn;

            this.manager = manager;
            this.subordinates = subordinates;
            if (this.subordinates == null)
                this.subordinates = new List<Employee>();
        }

        public Employee Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        public List<Employee> Subordinates
        {
            get { return subordinates; }
            set { subordinates = value; }
        }
        
        public bool isManager()
        {
            return Subordinates.Any();
        }
        
        public override string ToString()
        {
            return string.Format("ID={0};Name={1};SSN={2}", id.ToString(), name, ssn);
        }
    }
}
