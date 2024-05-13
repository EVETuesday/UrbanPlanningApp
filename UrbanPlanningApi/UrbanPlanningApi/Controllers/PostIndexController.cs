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
    public class PostIndexController : Controller
    {
        public readonly IConfiguration _configuration;
        public PostIndexController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllPostindexes")]
        public string GetPostindexes()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Postindex", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Postindex>postindexes = new List<Postindex>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Postindex postindex = new Postindex();
                    postindex.IDPostindex = Convert.ToInt32(dt.Rows[i]["IDPostindex"]);
                    postindex.Postindex1 = Convert.ToString(dt.Rows[i]["Postindex"]);
                    postindexes.Add(postindex);
                }
            }
            if (postindexes.Count > 0)
            {
                return JsonConvert.SerializeObject(postindexes);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
