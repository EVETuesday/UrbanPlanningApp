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
    public class FormatController : Controller
    {
        public readonly IConfiguration _configuration;
        public FormatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllFormats")]
        public string GetFormats()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Format", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Format> formats = new List<Format>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Format format = new Format();
                    format.IDFormat = Convert.ToInt32(dt.Rows[i]["IDFormat"]);
                    format.FormatTitle = Convert.ToString(dt.Rows[i]["FormatTitle"]);
                    formats.Add(format);
                }
            }
            if (formats.Count > 0)
            {
                return JsonConvert.SerializeObject(formats);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
