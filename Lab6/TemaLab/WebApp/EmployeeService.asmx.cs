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
        [WebMethod]
        public int add(int n1, int n2)
        {
            return n1 + n2;
        }

        [WebMethod]
        EmployeeData getEmployee(int id)
        {
            return new EmployeeData(id, "homer", "333-33-3333");
        }
    }

    public class EmployeeData
    {
        string name, ssn;
        [XmlAttribute()]
        int id;

        public EmployeeData() { }

        public EmployeeData(int id, string name, string ssn)
        {
            this.id = id;
            this.name = name;
            this.ssn = ssn;
        }

        public override string ToString()
        {
            return string.Format("ID={0};Name={1};SSN={2}", id, name, ssn);
        }
    }
}
