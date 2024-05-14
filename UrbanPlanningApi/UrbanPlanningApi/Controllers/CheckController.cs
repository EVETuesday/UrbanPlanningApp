using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using UrbanPlanningApi.Classes;
using static UrbanPlanningApi.Classes.CH;

namespace UrbanPlanningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : Controller
    {
        public readonly IConfiguration _configuration;
        public CheckController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllChecks")]
        public string GetChecks()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Check]", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Check> checks = new List<Check>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Check check = new Check();
                    check.IDCheck = Convert.ToInt32(dt.Rows[i]["IDCheck"]);
                    check.DateOfTheSale = Convert.ToDateTime(dt.Rows[i]["DateOfTheSale"]);
                    check.FullCost = Convert.ToDecimal(dt.Rows[i]["FullCost"]);
                    check.IDEstateObject = Convert.ToInt32(dt.Rows[i]["IDEstateObject"]);
                    check.IDClient = Convert.ToInt32(dt.Rows[i]["IDClient"]);
                    check.IDEmployee = Convert.ToInt32(dt.Rows[i]["IDEmployee"]);
                    checks.Add(check);
                }
            }
            if (checks.Count > 0)
            {
                return JsonConvert.SerializeObject(checks);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
        [HttpPost, ActionName("AddNewCheck")]
        [Route("AddNewCheck")]

        public string AddNewCheck(Check check)
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlCommand sc = new SqlCommand($"Insert into [Check] (DateOfTheSale, FullCost, IDEmployee, IDClient, IDEstateObject) Values(\'{check.DateOfTheSale}\', {check.FullCost.ToString().Split(',')[0]}.{check.FullCost.ToString().Split(',')[1]}, {check.IDEmployee}, {check.IDClient}, {check.IDEstateObject})", sqlConnection);
            sqlConnection.Open();
            int i = sc.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                return "Data is added";
            }
            else
            {
                return "Data isn't added";
            }
        }
    }
}
