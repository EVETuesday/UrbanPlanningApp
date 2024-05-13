using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using UrbanPlanningApi.Classes;
using static UrbanPlanningApi.Classes.CH;

namespace UrbanPlanningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        public readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public string GetEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> employees = new List<Employee>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.IDEmployee = Convert.ToInt32(dt.Rows[i]["IDEmployee"]);
                    employee.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    employee.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    employee.Patronymic = Convert.ToString(dt.Rows[i]["Patronymic"]);
                    employee.Birthday = Convert.ToDateTime(dt.Rows[i]["Birthday"]);
                    employee.Phone = Convert.ToString(dt.Rows[i]["Phone"]);
                    employee.PasportSeries = Convert.ToString(dt.Rows[i]["PasportSeries"]);
                    employee.PasportNumber = Convert.ToString(dt.Rows[i]["PasportNumber"]);
                    employee.IDGender = Convert.ToInt32(dt.Rows[i]["IDGender"]);
                    employee.IDPost = Convert.ToInt32(dt.Rows[i]["IDPost"]);
                    employee.Login = Convert.ToString(dt.Rows[i]["Login"]);
                    employee.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    employees.Add(employee);
                }
            }
            if (employees.Count > 0)
            {
                return JsonConvert.SerializeObject(employees);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
