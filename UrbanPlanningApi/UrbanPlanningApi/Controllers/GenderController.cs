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
    public class GenderController : Controller
    {
        public readonly IConfiguration _configuration;
        public GenderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllGenders")]
        public string GetGenders()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Gender", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Gender> genders = new List<Gender>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Gender gender = new Gender();
                    gender.IDGender = Convert.ToInt32(dt.Rows[i]["IDGender"]);
                    gender.GenderTitle = Convert.ToString(dt.Rows[i]["GenderTitle"]);
                    genders.Add(gender);
                }
            }
            if (genders.Count > 0)
            {
                return JsonConvert.SerializeObject(genders);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
