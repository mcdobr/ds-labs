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
            if (Session["managerMap"] == null)
                Session["managerMap"] = new Dictionary<Employee, Employee>();
            if (Session["subordinatesMap"] == null)
                Session["subordinatesMap"] = new Dictionary<Employee, List<Employee>>();
        }
        
        // Required (trebuie sa transform employee in manager?)
        [WebMethod(EnableSession = true)]
        public void addManager(Employee e)
        {
            // Am gandit-o ca se adauga inca o radacina in padurea de arbori
            ((List<Employee>)Session["employees"]).Add(e);
        }

        // Required
        [WebMethod(EnableSession = true)]
        public void addEmployee(Employee manager, Employee employee)
        {
            // Am gandit-o ca si cand se adauga un nod nou cu parintele manager
            var employees = Session["employees"] as List<Employee>;
            if (!employees.Contains(employee))
                employees.Add(employee);

            var subordinatesMap = Session["subordinatesMap"] as Dictionary<Employee, List<Employee>>;
            var managerMap = (Session["managerMap"]) as Dictionary<Employee, Employee>;

            if (!subordinatesMap.ContainsKey(manager))
                subordinatesMap[manager] = new List<Employee>();
            var subordinates = subordinatesMap[manager];

            if (!subordinates.Contains(employee))
            {
                subordinates.Add(employee);

                // Daca se creeaza un ciclu nu este adaugat
                if (isCyclic(manager))
                {
                    subordinates.Remove(employee);
                    Session["lastEdgeWasCycle"] = true;
                }
                else
                {
                    managerMap[employee] = manager;
                    Session["lastEdgeWasCycle"] = false;
                }
            }
        }


        // Required
        [WebMethod(EnableSession = true)]
        public Employee getManagerOf(Employee employee)
        {
            var managerMap = Session["managerMap"] as Dictionary<Employee, Employee>;
            return managerMap[employee];
        }

        // Required
        [WebMethod(EnableSession = true)]
        public Employee[] getEmployeesOf(Employee manager)
        {
            var subordinatesMap = Session["subordinatesMap"] as Dictionary<Employee, List<Employee>>;
            return subordinatesMap[manager].ToArray();
        }

        [WebMethod(EnableSession = true)]
        public Employee[] getAllEmployees()
        {
            return ((List<Employee>)Session["employees"]).ToArray();
        }

        [WebMethod(EnableSession = true)]
        public Employee createEmployee(string name, string ssn)
        {
            return new Employee(Guid.NewGuid(), name, ssn);
        }
        
        [WebMethod(EnableSession = true)]
        public bool wasCycle()
        {
            return (bool)Session["lastEdgeWasCycle"];
        }

        [WebMethod(EnableSession = true)]
        private bool isCyclic(Employee manager)
        {
            var visited = new HashSet<Employee>();
            var queue = new Queue<Employee>();
            var subordinatesMap = Session["subordinatesMap"] as Dictionary<Employee, List<Employee>>;

            queue.Enqueue(manager);
            visited.Add(manager);

            while (queue.Any())
            {
                Employee front = queue.Dequeue();

                if (subordinatesMap.ContainsKey(front))
                {
                    List<Employee> subs = subordinatesMap[front];
                    foreach (Employee sub in subs)
                    {
                        if (visited.Contains(sub))
                            return true;

                        queue.Enqueue(sub);
                        visited.Add(sub);
                    }
                }
            }

            return false;
        }
    }
    
    public class Employee
    {
        [XmlAttribute]
        public Guid id;
        public string name, ssn;

        public Employee() { }

        public Employee(Guid id, string name, string ssn, Employee manager = null, List<Employee> subordinates = null)
        {
            this.id = id;
            this.name = name;
            this.ssn = ssn;
        }
        
        public override string ToString()
        {
            return string.Format("ID={0};Name={1};SSN={2}", id.ToString(), name, ssn);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Employee emp = obj as Employee;

            return id == emp.id;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
