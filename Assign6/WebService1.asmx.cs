using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace Assign6
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public Employee Get(int id)

        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["webapi_conn"].ConnectionString);
            
            SqlDataAdapter da = new SqlDataAdapter("GetEmployeeByID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee emp = new Employee();
            if (dt.Rows.Count > 0)

            {
                emp.EmployeeId = Convert.ToInt32(dt.Rows[0]["EmployeeId"]);
                emp.EmployeeName = dt.Rows[0]["EmployeeName"].ToString();
                emp.DateOfJoining = Convert.ToDateTime(dt.Rows[0]["DateOfJoining"]);
                //emp.ActiveStatus = Convert.ToInt32(dt.Rows[0]["ActiveStatus"]);


            }
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }
    }
}
