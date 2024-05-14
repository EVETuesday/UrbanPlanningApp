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
    public class EstateObjectController : Controller
    {
        public readonly IConfiguration _configuration;
        public EstateObjectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEstateObjects")]
        public string GetEstateObjects()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstateObject", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EstateObject> estateObjects = new List<EstateObject>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EstateObject estateObject = new EstateObject();
                    estateObject.IDEstateObject = Convert.ToInt32(dt.Rows[i]["IDEstateObject"]);
                    estateObject.Square = Convert.ToDecimal(dt.Rows[i]["Square"]);
                    estateObject.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                    estateObject.DateOfDefinition = Convert.ToDateTime(dt.Rows[i]["DateOfDefinition"]);
                    estateObject.DateOfApplication = Convert.ToDateTime(dt.Rows[i]["DateOfApplication"]);
                    estateObject.Number = Convert.ToInt32(dt.Rows[i]["Number"]);
                    estateObject.Adress = Convert.ToString(dt.Rows[i]["Adress"]);
                    estateObject.IDPostIndex = Convert.ToInt32(dt.Rows[i]["IDPostIndex"]);
                    estateObject.IDTypeOfActivity = Convert.ToInt32(dt.Rows[i]["IDTypeOfActivity"]);
                    estateObject.IDFormat = Convert.ToInt32(dt.Rows[i]["IDFormat"]);
                    estateObjects.Add(estateObject);
                }
            }
            if (estateObjects.Count > 0)
            {
                return JsonConvert.SerializeObject(estateObjects);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }


        [HttpPost, ActionName("AddNewEstateObject")]
        [Route("AddNewEstateObject")]

        public string AddNewEstateObject(EstateObject estateObject)
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlCommand sc = new SqlCommand($"Insert into EstateObject (Square, Price, DateOfDefinition, DateOfApplication, Number, Adress, IDPostIndex, IDTypeOfActivity, IDFormat) Values({estateObject.Square.ToString().Split(',')[0]+"."+estateObject.Square.ToString().Split(',')[1]}, {estateObject.Price.ToString().Split(',')[0] + "." + estateObject.Price.ToString().Split(',')[1]}, \'{estateObject.DateOfDefinition}\', \'{estateObject.DateOfApplication}\', {estateObject.Number}, \'{estateObject.Adress}\', {estateObject.IDPostIndex}, {estateObject.IDTypeOfActivity},{estateObject.IDFormat})", sqlConnection);
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
