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
    public class EstatePhotoController : Controller
    {
        public readonly IConfiguration _configuration;
        public EstatePhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEstatePhotos")]
        public string GetEstatePhotos()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstatePhoto", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EstatePhoto> estatePhotos = new List<EstatePhoto>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EstatePhoto estatePhoto = new EstatePhoto();
                    estatePhoto.IDEstatePhoto = Convert.ToInt32(dt.Rows[i]["IDEstatePhoto"]);
                    estatePhoto.IDEmployee = Convert.ToInt32(dt.Rows[i]["IDEmployee"]);
                    estatePhoto.IDEstateObject = Convert.ToInt32(dt.Rows[i]["IDEstateObject"]);
                    estatePhoto.PhotoPath = Convert.ToString(dt.Rows[i]["PhotoPath"]);
                    estatePhotos.Add(estatePhoto);
                }
            }
            if (estatePhotos.Count > 0)
            {
                return JsonConvert.SerializeObject(estatePhotos);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
