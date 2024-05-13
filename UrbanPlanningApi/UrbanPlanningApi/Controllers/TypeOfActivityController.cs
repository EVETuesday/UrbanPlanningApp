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
    public class TypeOfActivityController : Controller
    {

        public readonly IConfiguration _configuration;
        public TypeOfActivityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllTypeOfActivity")]
        public string GetTypeOfActivity()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TypeOfActivity", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<TypeOfActivity> typeOfActivitys = new List<TypeOfActivity>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TypeOfActivity typeOfActivity = new TypeOfActivity();
                    typeOfActivity.IDTypeOfActivity = Convert.ToInt32(dt.Rows[i]["IDTypeOfActivity"]);
                    typeOfActivity.Title = Convert.ToString(dt.Rows[i]["Title"]);
                    typeOfActivitys.Add(typeOfActivity);
                }
            }
            if (typeOfActivitys.Count > 0)
            {
                return JsonConvert.SerializeObject(typeOfActivitys);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
