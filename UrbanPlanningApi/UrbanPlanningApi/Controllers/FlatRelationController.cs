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
    public class FlatRelationController : Controller
    {
        public readonly IConfiguration _configuration;
        public FlatRelationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllFlatRelations")]
        public string GetFlatRelations()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM FlatRelation", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<FlatRelation> flatRelations = new List<FlatRelation>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FlatRelation flatRelation = new FlatRelation();
                    flatRelation.IDFlatRelation = Convert.ToInt32(dt.Rows[i]["IDFlatRelation"]);
                    flatRelation.IDFlatEstate = Convert.ToInt32(dt.Rows[i]["IDFlatEstate"]);
                    flatRelation.IDBuildEstate = Convert.ToInt32(dt.Rows[i]["IDBuildEstate"]);
                    flatRelations.Add(flatRelation);
                }
            }
            if (flatRelations.Count > 0)
            {
                return JsonConvert.SerializeObject(flatRelations);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }

        [HttpPost, ActionName("AddNewFlatRelations")]
        [Route("AddNewFlatRelations")]

        public string AddNewFlatRelations(FlatRelation flatRelation)
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlCommand sc = new SqlCommand($"Insert into FlatRelation (IDBuildEstate, IDFlatEstate) Values({flatRelation.IDBuildEstate}, {flatRelation.IDFlatEstate})", sqlConnection);
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
