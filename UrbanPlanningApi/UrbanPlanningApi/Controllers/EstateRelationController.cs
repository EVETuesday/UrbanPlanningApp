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
    public class EstateRelationController : Controller
    {
        public readonly IConfiguration _configuration;
        public EstateRelationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEstateRelations")]
        public string GetEstateRelations()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstateRelation", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EstateRelation> estateRelations = new List<EstateRelation>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EstateRelation estateRelation = new EstateRelation();
                    estateRelation.IDEstateRelation = Convert.ToInt32(dt.Rows[i]["IDEstateRelation"]);
                    estateRelation.IDPlaceEstate = Convert.ToInt32(dt.Rows[i]["IDPlaceEstate"]);
                    estateRelation.IDBuildingEstate = Convert.ToInt32(dt.Rows[i]["IDBuildingEstate"]);
                    estateRelations.Add(estateRelation);
                }
            }
            if (estateRelations.Count > 0)
            {
                return JsonConvert.SerializeObject(estateRelations);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
